using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoldStage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform holdButton;
    [SerializeField] private Image fillImage;
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
            fillImage.color = Color.green;
            holdTimer += Time.deltaTime;

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                isHold = false;
            }
        }
        else
        {
            fillImage.color = Color.red;
            holdTimer -= Time.deltaTime;
        }

        if (isFirstHold)
        {
            if (holdButton.anchoredPosition.x >= 411f)
            {
                buttonDirection = new Vector3(Random.Range(-1f, 0f), Random.Range(-1f, 1f));
            }
            else if (holdButton.anchoredPosition.x <= -411f)
            {
                buttonDirection = new Vector3(Random.Range(0f, 1f), Random.Range(-1f, 1f));
            }
            else if (holdButton.anchoredPosition.y >= 411f)
            {
                buttonDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0f));
            }
            else if (holdButton.anchoredPosition.y <= -411f)
            {
                buttonDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 1f));
            }

            holdButton.position += buttonDirection.normalized * buttonSpeed * Time.deltaTime;
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
        isFirstHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = false;
    }
}
