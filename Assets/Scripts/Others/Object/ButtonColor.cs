using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    Image image;

    int index = 0;
    [SerializeField] private Color[] colors = { Color.black, Color.red, Color.green, Color.magenta, Color.blue, Color.yellow, Color.gray };
    
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        image.color = colors[index = Random.Range(0, colors.Length)];
    }
    
    public void ChangeColor()
    {
        image.color = colors[(++index) % colors.Length];
    }

}
