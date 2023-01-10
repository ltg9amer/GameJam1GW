using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymmetryStage : MonoBehaviour
{
    [SerializeField] Image lImage1;
    [SerializeField] Image lImage2;
    [SerializeField] Image lImage3;
    [SerializeField] Image lImage4;

    [SerializeField] Image rImage1;
    [SerializeField] Image rImage2;
    [SerializeField] Image rImage3;
    [SerializeField] Image rImage4;

    private void Update()
    {
        if (lImage1.color == rImage1.color && lImage2.color == rImage2.color && lImage3.color == rImage3.color && lImage4.color == rImage4.color)
        {
            GameManager.instance.GamePlaying();
        }
    }
}
