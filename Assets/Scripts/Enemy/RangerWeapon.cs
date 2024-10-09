using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class RangerWeapon : MonoBehaviour
{
    public float TimeToLive = 7f;

    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") | collision.CompareTag("Wall"))
        {
            Player e = null;
            if (collision.TryGetComponent(out e))
            {
                e.TakeDamage(10);
                Destroy(gameObject);
            }

            Destroy(gameObject);
        }
    }
}
