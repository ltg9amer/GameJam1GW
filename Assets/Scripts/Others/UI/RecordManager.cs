using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI devRecord;
    [SerializeField] private TextMeshProUGUI bestRecord;

    private void Start()
    {
        devRecord.text = $"Developer Record\n{Mathf.Floor(PlayerPrefs.GetInt("DevRecord", 86) / 60)} : {Mathf.Floor(PlayerPrefs.GetInt("DevRecord", 86) % 60).ToString("00")}";
        bestRecord.text = $"Best Record\n{Mathf.Floor(PlayerPrefs.GetInt("Record", 86) / 60)} : {Mathf.Floor(PlayerPrefs.GetInt("Record", 86) % 60).ToString("00")}";
    }

    [ContextMenu("Delete Best Record")]
    public void DeleteBestRecord()
    {
        PlayerPrefs.DeleteKey("Record");
    }
}
