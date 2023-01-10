using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowStage : MonoBehaviour
{
    [SerializeField] private int arrowLel = 6;

    [SerializeField] List<GameObject> prefabsList = new List<GameObject>();

    [SerializeField] List<GameObject> arrowList = new List<GameObject>();

    private int pointer = 0;

    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        pointer = 0;
        for (int i = 0; i < arrowLel; i++)
        {
            GameObject obj = Instantiate(prefabsList[UnityEngine.Random.Range(0, prefabsList.Count)], new Vector2(transform.position.x - (arrowLel / 2) + i * 1.2f, transform.position.x), Quaternion.identity);
            int a = UnityEngine.Random.Range(0, 4);
            obj.transform.rotation = Quaternion.Euler(0, 0, a * 90);
            obj.name = a.ToString();
            arrowList.Add(obj);
        }
    }

    private void Update()
    {
        Debug.Log(pointer);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (arrowList[pointer].name == "0")
            {
                RemoveObj();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (arrowList[pointer].name == "2")
            {
                RemoveObj();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (arrowList[pointer].name == "3")
            {
                RemoveObj();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (arrowList[pointer].name == "1")
            {
                RemoveObj();
            }
        }
    }

    private void RemoveObj()
    {
        Destroy(arrowList[pointer]);
        arrowList.RemoveAt(pointer);
        if (arrowList.Count == 0)
        {
            Debug.Log("���� ��������");
            GameManager.instance.GamePlaying();
        }
    }
}
