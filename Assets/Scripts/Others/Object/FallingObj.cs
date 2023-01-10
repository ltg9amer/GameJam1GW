using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObj : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "VoidPlayer")
        {
            Debug.Log(1);
            GameObject.Find("VoidPlayer").GetComponent<VoidObject>().InitStage();
            Destroy(gameObject);
        }
    }
}
