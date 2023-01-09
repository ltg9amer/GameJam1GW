using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymmetryStage : MonoBehaviour
{
    [SerializeField] private Image _image1;
    [SerializeField] private Image _image2;
    
    private void Update()
    {
        if(_image1.color == _image2.color)
        {
            GameManager.instance.GamePlaying();
        }
    }
}
