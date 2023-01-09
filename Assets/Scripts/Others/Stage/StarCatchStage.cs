using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarCatchStage : MonoBehaviour
{
    [SerializeField] private bool clickDelay = false;

    private void OnEnable()
    {
        Move();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickDelay == false)
        {
            clickDelay = true;
            Invoke("DelayChange", 0.5f);
        }
    }

    void DelayChange()
    {
        clickDelay = false;
    }

    private void Move()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(new Vector2(3, 0), 0.5f).SetEase(Ease.Linear))
        .Append(transform.DOMove(new Vector2(-3, 0), 0.5f).SetEase(Ease.Linear))
        .OnComplete(() =>
        {
            seq.Kill();
            Move();
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0) && clickDelay == false)
        {
            //오디오소스 플레이시키기
            Debug.Log(1);
            GameManager.instance.GamePlaying();
        }
    }
}
