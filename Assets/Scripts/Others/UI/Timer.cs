using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.NetworkInformation;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    private float minute = 0;
    public float Minute => minute;
    private float second = 0;
    public float Second => second;

    [SerializeField] private bool isRecording = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (isRecording)
        {
            second += Time.deltaTime;
            minute = MathF.Floor(second / 60);
            if (second >= 10)
            {
                Debug.Log($"0{minute} : {Mathf.Floor(second % 60)}");
            }
            else
            {
                Debug.Log($"0{minute} : 0{Mathf.Floor(second % 60)}");
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
