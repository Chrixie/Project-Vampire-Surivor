using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpSwoop : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.XpGain();
            Destroy(gameObject);
        }
    }




}
