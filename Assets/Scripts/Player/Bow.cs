using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bow : MonoBehaviour
{
    [SerializeField] GameObject ArrowPreFab;
    [SerializeField] float ArrowSpeed;
    private bool canShootPress = false;
    public float cooldownPress = .2f;
    private bool canShootHold = false;
    public float cooldownHold { get; set; }

private void Start()
    {
        cooldownHold = 1f;
       // StartCoroutine(RegulatePress());
        StartCoroutine(RegulateHold());
    }

    public void ShootUpdate()
    {
        //ShootArrowPress();
        ShootArrowHold();
    }

    void ShootArrow()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 ArrowDirection = mousePos - (Vector2)transform.position;

        GameObject Arrow = Instantiate(ArrowPreFab, transform.position, Quaternion.identity);
        Arrow.GetComponent<Rigidbody2D>().velocity = ArrowDirection.normalized * ArrowSpeed;
        Arrow.transform.up = ArrowDirection;
    }

    //Shooting while pressing
    /*void ShootArrowPress()
    {
        if (canShootPress && Input.GetMouseButtonDown(0))
        {
            ShootArrow();
            canShootPress = false;
        }
    }
    private IEnumerator RegulatePress()
    {
        while (true)
        {
            if (!canShootPress)
            {
                yield return new WaitForSeconds(cooldownPress);
                canShootPress = true;
            }
            yield return null;
        }
    }*/

    //Shooting while Holding
    void ShootArrowHold()
    {
        if (canShootHold && Input.GetMouseButton(1))
        {
            ShootArrow();
            canShootHold = false;
        }
    }
    private IEnumerator RegulateHold()
    {
        while (true)
        {
            if (!canShootHold)
            {
                yield return new WaitForSeconds(cooldownHold);
                canShootHold = true;
            }
            yield return null;
        }
    }
}
