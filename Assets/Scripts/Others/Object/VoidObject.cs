using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VoidObject : MonoBehaviour
{
    private Camera mainCam;
    private TextMeshProUGUI noticeText;
    private float x;

    [SerializeField] List<GameObject> obstacles = new List<GameObject>();

    GameObject[] arr;

    private void OnEnable()
    {
        mainCam = Camera.main;
        noticeText = GameObject.Find("NoticeText").GetComponent<TextMeshProUGUI>();
        InitStage();
    }

    public void InitStage()
    {
        StopAllCoroutines();
        transform.position = new Vector3(transform.position.x, 4f);
        arr = GameObject.FindGameObjectsWithTag("FallingObj");
        for (int i = 0; i < arr.Length; i++)
        {
            Destroy(arr[i]);
        }
        StartCoroutine(DropperStage());
    }

    IEnumerator DropperStage()
    {
        noticeText.text = "모든 블록을 피해 떨어지세요!";
        List<GameObject> obstacleList = new List<GameObject>();
        for (int i = 0; i < obstacles.Count; i++)
        {
            Instantiate(obstacles[i], new Vector2(0, -5), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(0.5f);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(new Vector3(transform.position.x, -4f), 1f))
            .Join(noticeText.DOFade(0f, 1f))
            .AppendCallback(() =>
            {
                noticeText.text = "떨어지는 블록을 피하세요!";
            })
            .Append(noticeText.DOFade(1f, 1f))
            .OnComplete(() =>
            {
                StartCoroutine(AvoidStage());
            });
    }

    IEnumerator AvoidStage()
    {
        for (int i = obstacles.Count - 1; i >= 0; i--)
        {
            Rigidbody2D obstacleRigid = Instantiate(obstacles[i], new Vector2(0, 5), Quaternion.identity).GetComponent<Rigidbody2D>();
            obstacleRigid.gravityScale = -obstacleRigid.gravityScale;
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(0.7f);
        noticeText.text = string.Empty;
        GameManager.instance.GamePlaying();
    }

    void Update()
    {
        x = mainCam.ScreenToWorldPoint(Input.mousePosition).x;

        if (x > 3.6f)
        {
            x = 3.6f;
        }
        else if (x < -3.6f)
        {
            x = -3.6f;
        }

        transform.position = new Vector2(x, transform.position.y);
    }
}
