using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StarCatchStage : MonoBehaviour
{
    Sequence seq;

    [SerializeField] private GameObject hitArea;
    [SerializeField] private Image image;
    private GameObject cam;

    bool isTiming = false;

    private void OnEnable()
    {
        hitArea.transform.position = new Vector3(Random.Range(-3f, 3f), transform.position.y, transform.position.z);
        cam = Camera.main.gameObject;
        Move();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(1);
            if (isTiming == true)
            {
                seq.Kill();
                GameManager.instance.GamePlaying();
            }
            else
            {
                seq.Kill();
                transform.position = new Vector2(-3, 0);
                Move();
                Shake();
            }
        }
    }

    private void Shake()
    {
        Sequence sequence = DOTween.Sequence()
        .Append(image.DOFade(0.7f, 0.1f))
        .Join(cam.transform.DOShakePosition(0.1f))
        .Append(image.DOFade(0, 0.1f));
    }

    private void Move()
    {
        seq = DOTween.Sequence();
        seq.Append(transform.DOMove(new Vector2(3, 0), 0.35f).SetEase(Ease.Linear))
        .Append(transform.DOMove(new Vector2(-3, 0), 0.35f).SetEase(Ease.Linear))
        .OnComplete(() =>
        {
            seq.Kill();
            Move();
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTiming = true;
        Debug.Log("OnTriggerEnter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTiming = false;
    }
}
