using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimStage : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject min;
    [SerializeField] private GameObject max;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(ball, SetPos(), Quaternion.identity);
            obj.transform.SetParent(transform, true);
        }
        GameObject last = new GameObject();
        last.name = "QWEOQW_2312_123_QVMK";
        last.transform.SetParent(transform, true);
    }

    private void Update()
    {
        if(transform.GetChild(2).name == "QWEOQW_2312_123_QVMK")
        {
            Debug.Log("다음 스테이지");
            GameManager.instance.GamePlaying();
        }
    }

    Vector2 SetPos()
    {
        return new Vector2(Random.Range(min.transform.position.x, max.transform.position.x), Random.Range(min.transform.position.y, max.transform.position.y));
    }
}
