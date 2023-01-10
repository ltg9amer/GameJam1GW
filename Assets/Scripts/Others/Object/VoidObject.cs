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
        noticeText.text = "떨어지는 블록을 피하세요!";
        InitStage();
    }

    public void InitStage()
    {
        StopAllCoroutines();
        arr = GameObject.FindGameObjectsWithTag("FallingObj");
        for (int i = 0; i < arr.Length; i++)
        {
            Destroy(arr[i]);
        }
        StartCoroutine(StartStage());
    }

    IEnumerator StartStage()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            Instantiate(obstacles[i], new Vector2(0, 5), Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(1.2f);
        noticeText.text = string.Empty;
        GameManager.instance.GamePlaying();
    }

    void Update()
    {
        x = mainCam.ScreenToWorldPoint(Input.mousePosition).x;

        if (x > 4)
        {
            x = 4;
        }
        else if (x < -4)
        {
            x = -4;
        }

        transform.position = new Vector2(x, transform.position.y);
    }
}
