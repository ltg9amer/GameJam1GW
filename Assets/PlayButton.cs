using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayButton : MonoBehaviour
{
    public void ClickPlayButton()
    {
        GameManager.instance.GameStart();
    }
}
