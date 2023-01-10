using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectUI : MonoBehaviour
{
    [SerializeField] private GameObject followObject;

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(followObject.transform.position + new Vector3(0f, followObject.GetComponent<Collider2D>().bounds.size.y / 2f));
    }
}
