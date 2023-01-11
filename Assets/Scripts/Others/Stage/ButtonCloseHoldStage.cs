using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCloseHoldStage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform imageRect;
    [SerializeField] private Image fillImage1;
    [SerializeField] private Image fillImage2;
    [SerializeField] private float maxHoldTime;
    [SerializeField] private float buttonSpeed;
    private Vector3 buttonDirection;
    private float holdTimer;
    private bool isHold;
    private bool isFirstHold;

    private void OnEnable()
    {
        buttonDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    private void Update()
    {
        if (isHold)
        {
            holdTimer += Time.deltaTime;

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                isHold = false;
            }
        }
        else
        {
            holdTimer -= Time.deltaTime;
        }

        if (isFirstHold)
        {
            if (imageRect.anchoredPosition.x >= 411f)
            {
                buttonDirection = new Vector3(Random.Range(-1f, 0f), Random.Range(-1f, 1f));
            }
            else if (imageRect.anchoredPosition.x <= -411f)
            {
                buttonDirection = new Vector3(Random.Range(0f, 1f), Random.Range(-1f, 1f));
            }
            else if (imageRect.anchoredPosition.y >= 411f)
            {
                buttonDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0f));
            }
            else if (imageRect.anchoredPosition.y <= -411f)
            {
                buttonDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f));
            }

            imageRect.position += buttonDirection.normalized * buttonSpeed * Time.deltaTime;
        }

        holdTimer = Mathf.Clamp(holdTimer, 0f, maxHoldTime);

        fillImage1.fillAmount = holdTimer / maxHoldTime;
        fillImage2.fillAmount = holdTimer / maxHoldTime;

        if (holdTimer >= maxHoldTime)
        {
            GameManager.instance.GamePlaying();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHold = true;
        isFirstHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = false;
    }
}
