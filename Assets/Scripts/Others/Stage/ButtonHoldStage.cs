using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoldStage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image fillImage;
    [SerializeField] private float maxHoldTime;
    private float holdTimer;
    private bool isHold;

    private void Update()
    {
        if (isHold)
        {
            fillImage.color = Color.green;
            holdTimer += Time.deltaTime;
        }
        else
        {
            fillImage.color = Color.red;
            holdTimer -= Time.deltaTime;
        }

        holdTimer = Mathf.Clamp(holdTimer, 0f, maxHoldTime);

        fillImage.fillAmount = holdTimer / maxHoldTime;

        if (holdTimer >= maxHoldTime)
        {
            GameManager.instance.GamePlaying();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = false;
    }
}
