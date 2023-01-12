using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI caption;


    private void OnEnable()
    {
        if (GameManager.instance.IsClear)
        {
            //Ŭ����
            resultText.text = "CLEAR!!";
            if (Timer.instance.Second >= 10)
            {
                caption.text = $"0{Timer.instance.Minute} : {Mathf.Floor(Timer.instance.Second % 60)}";
            }
            else
            {
                caption.text = $"0{Timer.instance.Minute} : {Mathf.Floor(Timer.instance.Second % 60)}";
            }
        }
        else
        {
            resultText.text = "Fail...";
            caption.text = $"{GameManager.instance.CurrentStage - 1} Stage Ŭ����, ������{GameManager.instance.stageCount - GameManager.instance.CurrentStage + 1}����";
        }
    }

    public void BtnClick()
    {
        Debug.Log("���ư���");
        SceneManager.LoadScene("MainScene");
    }
}