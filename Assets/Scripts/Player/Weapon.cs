using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float TimeToLive = 7f;

    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy e = null;
            if (collision.TryGetComponent(out e))
            {
                e.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
