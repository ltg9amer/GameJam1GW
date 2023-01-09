using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;

public class MultiplicationStage : MonoBehaviour
{
    private int a;
    private int b;

    private int flag;

    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;

    [SerializeField] private TextMeshProUGUI answer;
    [SerializeField] private TextMeshProUGUI fake;
    [SerializeField] private TextMeshProUGUI quiz;

    private void OnEnable()
    {
        a = Random.Range(1, 10);
        b = Random.Range(1, 10);

        flag = Random.Range(0, 2);
        if (flag == 0)
        {
            quiz.text = $"{a} X {b} = {a * b} ";
            answer.text = "O";
            fake.text = "X";
        }
        else
        {
            quiz.text = $"{a} X {b} = {a * b + Random.Range(1, 5)} ";
            answer.text = "X";
            fake.text = "O";
        }

        flag = Random.Range(0, 2);
        if(flag == 0) 
        {
            GameObject.Find("Y").transform.position = left.transform.position;
            GameObject.Find("N").transform.position = right.transform.position;
        }
        else
        {
            GameObject.Find("N").transform.position = left.transform.position;
            GameObject.Find("Y").transform.position = right.transform.position;
        }
    }

    public void NextStage()
    {
        GameManager.instance.GamePlaying();
    }
}
