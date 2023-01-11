using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    private float angle;
    private void Update()
    {
        angle += Time.deltaTime * 100;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0, angle));
    }
}
