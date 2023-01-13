using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestRecord;

    private void Start()
    {
        bestRecord.text = $"Best Record\n{Mathf.Floor(PlayerPrefs.GetInt("Record", 86) / 60)} : {Mathf.Floor(PlayerPrefs.GetInt("Record", 86) % 60).ToString("00")}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.T))
            {
                DeleteBestRecord();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.T))
            {
                DeleteBestRecord();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.T))
            {
                DeleteBestRecord();
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.R))
            {
                DeleteBestRecord();
            }
        }
    }

    [ContextMenu("Delete Best Record")]
    public void DeleteBestRecord()
    {
        PlayerPrefs.DeleteKey("Record");
    }
}
