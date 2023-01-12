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
    /// 타이머를 시작하고 작동 여부를 반환
    /// </summary>
    /// <returns></returns>
    public bool StartRecord()
    {
        if (isRecording)
        {
            Debug.LogWarning("이미 시간을 기록중입니다!");
            return false;
        }
        else
        {
            second = 0;
            minute = 0;
            isRecording = true;
            Debug.Log("기록 시작");
            return true;
        }
    }

    [ContextMenu("StopRecord")]
    /// <summary>
    /// 타이머를 멈추고 정지 여부를 반환
    /// </summary>
    /// <returns></returns>
    public bool StopRecord()
    {
        if (isRecording == false)
        {
            Debug.LogWarning("기록을 하고 있지 않음");
            return false;
        }
        else
        {
            isRecording = false;
            Debug.Log("기록 중지");
            return true;
        }
    }
}
