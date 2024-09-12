using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Rigidbody2D rb;
    private float Direction;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindFirstObjectByType<Player>().gameObject;
        
    }
    void Update()
    {
        transform.position += (player.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;

    }

}

