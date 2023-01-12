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
            //클리어
            resultText.text = "CLEAR!!";
            if (Timer.instance.Second >= 10)
                caption.text = $"{Timer.instance.Minute} : {Mathf.Floor(Timer.instance.Second % 60).ToString("00")}";
        }
        else
        {
            resultText.text = "Fail...";
            caption.text = $"{GameManager.instance.CurrentStage} Stage 클리어, 앞으로 {GameManager.instance.stageCount - GameManager.instance.CurrentStage} Stage 남음";
        }
    }

    public void BtnClick()
    {
        Debug.Log("돌아가기");
        SceneManager.LoadScene("MainScene");
    }
}
