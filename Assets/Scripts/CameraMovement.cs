using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        transform.position = Player.position + new Vector3(0, 0, -5);
    }
}
