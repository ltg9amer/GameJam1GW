using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyBirdStage : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private float flySpeed;
    [SerializeField] private float jumpPower;
    private GameObject worm;
    private Collider2D nest;
    private Rigidbody2D _rigidbody2D;
    private TextMeshProUGUI noticeText;
    private bool isTurn;
    private bool isBack;

    private void OnEnable()
    {
        Transform obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)]).GetComponent<Transform>();
        obstacle.SetParent(transform.parent);

        worm = GameObject.Find("Worm");
        nest = GameObject.Find("Nest").GetComponent<Collider2D>();
        nest.enabled = false;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        noticeText = GameObject.Find("NoticeText").GetComponent<TextMeshProUGUI>();

        InitStage();
    }

    public void InitStage()
    {
        transform.position = new Vector3(-4f, 0f);
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y);

        worm.SetActive(true);
        
        _rigidbody2D.velocity = Vector3.zero;
        noticeText.transform.position = Vector3.zero;
        noticeText.text = "장애물을 피해 먹이를 잡으세요!";
        isBack = false;
    }

    private void Update()
    {
        if (!isTurn)
        {
            transform.position += (isBack ? Vector3.left : Vector3.right) * flySpeed * Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                _rigidbody2D.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Worm")
        {
            collision.gameObject.SetActive(false);

            Sequence sequence = DOTween.Sequence(); 

            sequence.AppendCallback(() =>
            {
                isTurn = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
                _rigidbody2D.gravityScale = 0f;
                _rigidbody2D.velocity = Vector3.zero;
            })
                .Append(transform.DOMove(collision.transform.position, 0.5f))
                .Join(noticeText.DOFade(0f, 0.5f))
                .AppendCallback(() =>
                {
                    noticeText.text = "장애물을 피해 둥지로 돌아가세요!";
                })
                .Append(noticeText.DOFade(1f, 0.5f))
                .AppendCallback(() =>
                {
                    isTurn = false;
                    isBack = true;
                    nest.enabled = true;
                    _rigidbody2D.gravityScale = 1f;
                });
        }
        else if (collision.name == "Nest")
        {
            noticeText.transform.position = new Vector3(0f, 150f);
            noticeText.text = string.Empty;
            GameManager.instance.GamePlaying();
        }
        else if (collision.CompareTag("FallingObj"))
        {
            nest.enabled = false;

            InitStage();
        }
    }
}
