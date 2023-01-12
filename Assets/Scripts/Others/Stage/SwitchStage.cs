using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStage : MonoBehaviour
{
    [SerializeField] private List<Switch> switches;

    private void OnEnable()
    {
        SwitchCheck();
    }

    public void SwitchCheck()
    {
        foreach (Switch sw in switches)
        {
            if (!sw.IsOn)
            {
                return;
            }
        }

        GameManager.instance.GamePlaying();
    }
}
