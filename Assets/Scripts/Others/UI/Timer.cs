using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.NetworkInformation;
using System;

public class Timer : MonoBehaviour
{
    private float minute = 0;
    private float second = 0;

    [SerializeField] private bool isRecording = true;

    TextMeshProUGUI timerTxt;

    private void Awake()
    {
        timerTxt = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isRecording)
        {
            second += Time.deltaTime;
            minute = MathF.Floor(second / 60);
            if (second >= 10)
            {
                timerTxt.text = $"0{minute} : {Mathf.Floor(second)}";
            }
            else
            {
                timerTxt.text = $"0{minute} : 0{Mathf.Floor(second)}";
            }
        }
    }

    [ContextMenu("StartRecord")]
    /// <summary>
    /// Ÿ�̸Ӹ� �����ϰ� �۵� ���θ� ��ȯ
    /// </summary>
    /// <returns></returns>
    public bool StartRecord()
    {
        if (isRecording)
        {
            Debug.LogWarning("�̹� �ð��� ������Դϴ�!");
            return false;
        }
        else
        {
            second = 0;
            minute = 0;
            isRecording = true;
            Debug.Log("��� ����");
            return true;
        }
    }

    [ContextMenu("StopRecord")]
    /// <summary>
    /// Ÿ�̸Ӹ� ���߰� ���� ���θ� ��ȯ
    /// </summary>
    /// <returns></returns>
    public bool StopRecord()
    {
        if (isRecording == false)
        {
            Debug.LogWarning("����� �ϰ� ���� ����");
            return false;
        }
        else
        {
            isRecording = false;
            Debug.Log("��� ����");
            return true;
        }
    }
}
