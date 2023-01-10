using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class BubbleStage : MonoBehaviour
{
    Camera mainCam;
    float x, y;

    [SerializeField] private List<GameObject> balloon = new List<GameObject>();
    [SerializeField] private GameObject rootObj;
    private TextMeshProUGUI noticeText;

    void Awake()
    {
        mainCam = Camera.main;
        noticeText = GameObject.Find("NoticeText").GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(balloon[UnityEngine.Random.Range(0, balloon.Count)], new Vector2(UnityEngine.Random.Range(-4f, 4f), UnityEngine.Random.Range(-4f, 4f)), quaternion.identity);
            obj.transform.SetParent(rootObj.transform);
        }

        noticeText.text = "모든 풍선을 터뜨리세요!";

        GameObject last = new GameObject();
        last.name = "SFDIO_DSFKJN_E123_GWQ";
        last.transform.SetParent(rootObj.transform);
    }

    void Update()
    {
        if (rootObj.transform.GetChild(1).name == "SFDIO_DSFKJN_E123_GWQ")
        {
            Debug.Log("다음 스테이지");
            noticeText.text = string.Empty;
            GameManager.instance.GamePlaying();
        }

        x = mainCam.ScreenToWorldPoint(Input.mousePosition).x;
        y = mainCam.ScreenToWorldPoint(Input.mousePosition).y;

        if (x <= -4f)
        {
            x = -4f;
        }
        else if (x >= 4f)
        {
            x = 4f;
        }

        if (y <= -4f)
        {
            y = -4f;
        }
        else if (y >= 4f)
        {
            y = 4f;
        }

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
