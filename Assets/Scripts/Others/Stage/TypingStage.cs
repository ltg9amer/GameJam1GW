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

        Invoke("Select", 0f);
    }

    private void Select()
    {
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
            typingField.ActivateInputField();
            typingField.text = string.Empty;
        }
    }
}
