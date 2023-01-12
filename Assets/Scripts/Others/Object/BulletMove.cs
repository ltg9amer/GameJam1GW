using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private void OnEnable()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
