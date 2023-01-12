using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] AudioClip _audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pin")
        {
            AudioSource.PlayClipAtPoint(_audio, transform.position);
            Destroy(gameObject);
        }
    }
}
