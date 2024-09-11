using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bow : MonoBehaviour
{
    [SerializeField] GameObject ArrowPreFab;
    [SerializeField] float ArrowSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 ArrowDirection = mousePos - (Vector2)transform.position;

            //GameObject Arrow = Instantiate(ArrowPreFab);
            //GameObject Arrow = Instantiate(ArrowPreFab, transform);
            GameObject Arrow = Instantiate(ArrowPreFab, transform.position, Quaternion.identity);
            Arrow.GetComponent<Rigidbody2D>().velocity = ArrowDirection.normalized * ArrowSpeed;
            Arrow.transform.up = ArrowDirection;

        }
    }
}
