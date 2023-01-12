using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI caption;
    [SerializeField] private TextMeshProUGUI bestRecord;

    private void OnEnable()
    {
        if (GameManager.instance.IsClear)
        {
#if UNITY_EDITOR
            if ((int)Timer.instance.Second < PlayerPrefs.GetInt("DevRecord", 86))
            {
                PlayerPrefs.SetInt("DevRecord", (int)Timer.instance.Second);
            }
#endif
            //Ŭ����
            if ((int)Timer.instance.Second < PlayerPrefs.GetInt("Record", 86))
            {
                PlayerPrefs.SetInt("Record", (int)Timer.instance.Second);
            }

            resultText.text = "CLEAR!!!";
            caption.text = $"Current: {Timer.instance.Minute} : {Mathf.Floor(Timer.instance.Second % 60).ToString("00")}";
            if (PlayerPrefs.GetInt("Record", 86) != 86)
            {
                bestRecord.text = $"Best: {Mathf.Floor(PlayerPrefs.GetInt("Record") / 60)} : {Mathf.Floor(PlayerPrefs.GetInt("Record") % 60).ToString("00")}";
            }
        }
        else
        {
            resultText.text = "FAIL...";
            caption.text = $"{GameManager.instance.CurrentStage} Stage Ŭ����, ������ {GameManager.instance.stageCount - GameManager.instance.CurrentStage} Stage ����";
        }
    }

    public void BtnClick()
    {
        Debug.Log("���ư���");
        SceneManager.LoadScene("MainScene");
    }
}
