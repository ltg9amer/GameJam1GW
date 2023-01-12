using DG.Tweening;
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
        Sequence seq = DOTween.Sequence();
        if (!GameManager.instance.CanLoadSetting) return;
        button.enabled = false;
        if (settingPanel.activeSelf)
        {
            seq.Append(settingPanel.transform.DOMove(hidePos.transform.position, 1))
            .AppendCallback(() =>
            {
                settingPanel.SetActive(!settingPanel.activeSelf);
                button.enabled = true;
            });
            //숨기기
        }
        else
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
            seq.Append(settingPanel.transform.DOMove(showPos.transform.position, 1))
            .AppendCallback(() =>
            {
                button.enabled = true;
            });
            //보여주기
        }
    }
}
