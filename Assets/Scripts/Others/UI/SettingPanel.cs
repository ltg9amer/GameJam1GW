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

    private void Start()
    {
        GameManager.instance.IsBeforeStart = true;
    }

    public void OnClick()
    {
        if (!GameManager.instance.CanLoadSetting) return;

        if (settingPanel.activeSelf)
        {
            Sequence seq = DOTween.Sequence()
            .Append(settingPanel.transform.DOMove(hidePos.transform.position, 1))
            .AppendCallback(() =>
            {
                settingPanel.SetActive(!settingPanel.activeSelf);
            });
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
