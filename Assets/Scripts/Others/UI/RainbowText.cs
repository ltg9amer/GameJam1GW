using UnityEngine;
using TMPro;
using System.Collections;
using DG.Tweening;

public class RainbowText : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;


    private void OnEnable()
    {
        ColorChange();
    }

    void ColorChange()
    {
        Sequence seq = DOTween.Sequence()
        .Append(text.DOColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)), 0.5f))
        .OnComplete(() =>
        {
            ColorChange();
        });
    }
}
