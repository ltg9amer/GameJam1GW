using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject hidePos;
    [SerializeField] GameObject showPos;
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnClick()
    {

        if (settingPanel.activeSelf)
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
            settingPanel.transform.DOMove(hidePos.transform.position, 1);
            //숨기기
        }
        else
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
            settingPanel.transform.DOMove(showPos.transform.position, 1);
            //보여주기
        }
    }
}
