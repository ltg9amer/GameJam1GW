using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingStage : MonoBehaviour
{
    [SerializeField] private List<string> sampleStrings;
    [SerializeField] private TextMeshProUGUI sampleText;
    [SerializeField] private TMP_InputField typingField; 

    private void OnEnable()
    {
        sampleText.text = sampleStrings[Random.Range(0, sampleStrings.Count)];
        typingField.ActivateInputField();
        typingField.Select();
    }

    public void OnEditEnd()
    {
        if (typingField.text.Equals(sampleText.text))
        {
            GameManager.instance.GamePlaying();
        }
        else
        {
            typingField.text = string.Empty;
        }
    }
}
