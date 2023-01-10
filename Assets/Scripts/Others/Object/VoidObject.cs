using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidObject : MonoBehaviour
{
    private Camera mainCam;
    private float x;

    [SerializeField] List<GameObject> obstacles = new List<GameObject>();

    GameObject[] arr;

    private void OnEnable()
    {
        mainCam = Camera.main;
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
