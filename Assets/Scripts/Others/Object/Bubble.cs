using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    AudioSource _audio;
    
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pin")
        {
            _audio?.Play();
            Destroy(gameObject);
        }
    }
}
