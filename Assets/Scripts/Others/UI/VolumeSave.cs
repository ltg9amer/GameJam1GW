using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSave : MonoBehaviour
{
    private Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();

        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        }
        else
        {
            volumeSlider.value = GameManager.instance.AudioSource.volume;
        }
    }

    public void VolumeChange()
    {
        GameManager.instance.AudioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", GameManager.instance.AudioSource.volume);
    }
}
