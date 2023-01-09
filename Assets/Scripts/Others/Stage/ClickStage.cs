using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ClickStage : MonoBehaviour
{
    [SerializeField] private float count = 0;
    [SerializeField] private float maxCount = 0;

    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        count = 0;
    }

    private void Update()
    {
        if (count >= 0)
        {
            count -= Time.deltaTime * 4;
        }
        
        if(Input.GetMouseButtonDown(0))
        {
            count++;
        }

        _slider.value = count / maxCount;

        if(count >= maxCount)
        {
            Debug.Log("다음 스테이지");
            Destroy(gameObject);
        }
    }
}
