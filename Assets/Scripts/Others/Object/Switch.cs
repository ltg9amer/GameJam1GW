using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    [SerializeField] private Sprite onSwitch;
    [SerializeField] private Sprite offSwitch;
    private Image image;
    private bool isOn;
    public bool IsOn => isOn;

    private void Awake()
    {
        image = GetComponent<Image>();
        isOn = Random.value > 0.2f;

        SwitchOnOff();
    }

    public void SwitchOnOff()
    {
        if (isOn)
        {
            isOn = false;
            image.sprite = offSwitch;
        }
        else
        {
            isOn = true;
            image.sprite = onSwitch;
        }
    }
}
