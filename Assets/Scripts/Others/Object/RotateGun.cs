using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateGun : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject rootObj;

    private float angle;

    private bool onClick = false;

    private void OnEnable()
    {

        GameObject obj1 = Instantiate(target, new Vector2(Random.Range(-4f, 4f), 4), Quaternion.identity);
        obj1.transform.SetParent(rootObj.transform, true);

        GameObject obj2 = Instantiate(target, new Vector2(Random.Range(-4f, 4f), -4), Quaternion.identity);
        obj2.transform.SetParent(rootObj.transform, true);

        GameObject obj3 = Instantiate(target, new Vector2(4, Random.Range(-4f, 4f)), Quaternion.identity);
        obj3.transform.SetParent(rootObj.transform, true);

        GameObject obj4 = Instantiate(target, new Vector2(-4, Random.Range(-4f, 4f)), Quaternion.identity);
        obj4.transform.SetParent(rootObj.transform, true);
        
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => onClick);
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClick = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            onClick = false;
        }

        RotateMouse();
    }

    void RotateMouse()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        angle = Mathf.Atan2(
            transform.position.y - mouseWorldPosition.y,
            transform.position.x - mouseWorldPosition.x) * Mathf.Rad2Deg + 90;

        Debug.Log(angle);
        // Y�� ȸ��
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0, angle));
    }
}
