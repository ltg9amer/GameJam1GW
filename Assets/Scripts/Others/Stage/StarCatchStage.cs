using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarCatchStage : MonoBehaviour
{
    [SerializeField] private bool clickDelay = false;
    Sequence seq;

    bool isTiming = false;

    private void OnEnable()
    {
        Move();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickDelay == false)
        {
            Debug.Log(1);
            clickDelay = true;
            Invoke("DelayChange", 0.2f);
        }
    }

    void DelayChange()
    {
        clickDelay = false;
        seq.Kill();
        transform.position = new Vector2(-3, 0);
        Move();
    }

    private void Move()
    {
        seq = DOTween.Sequence();
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
        isTiming = true;
        Debug.Log("OnTriggerEnter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTiming = false;
    }
}
