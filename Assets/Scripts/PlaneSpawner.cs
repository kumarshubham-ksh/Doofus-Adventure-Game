using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject planePrefab;
    int planeCount;

    public static Vector3[] spawnDistance = new Vector3[]
    {
        new Vector3(-9f, 0f, 0f),
        new Vector3(9f, 0f, 0f),
        new Vector3(0f, 0f, -9f),
        new Vector3(0f, 0f, 9f)
    };

    void Start()
    {
        planeCount = 0;
        Invoke("SpawnPlane", 1f);
    }

    void SpawnPlane()
    {
        GameObject newPlane = Instantiate(planePrefab, transform.position, Quaternion.identity);

        planeCount++;
        newPlane.GetComponent<PlaneManager>().AssignPlaneID(planeCount);

        Vector3 nextSpawnPosition = newPlane.transform.position + spawnDistance[Random.Range(0, 3)];
        if(planeCount < 50)
        {
            Invoke("SpawnPlane", 2.5f);
        }
        transform.position = nextSpawnPosition;
    }
}
