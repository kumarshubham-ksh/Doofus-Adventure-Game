using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float distanceX = 0f;
    [SerializeField] float distanceY = 6f;
    [SerializeField] float distanceZ = -8.5f;

    void Update()
    {
        Vector3 Direction = new Vector3(distanceX, distanceY, distanceZ);
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        transform.position = player.position + rotation * Direction;

        transform.LookAt(player.position);
    }
}