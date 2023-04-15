using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicles : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    private float spawnRangeX = 9;
    private float spawnPosZ = 379;
    
    private float startDelay = 2;
    private float spawnInterval = 2.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomVehicle", startDelay, spawnInterval);
    }

    void Update()
    {
        
    }

    void SpawnRandomVehicle()
    {
        int vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        
        Instantiate(vehiclePrefabs[vehicleIndex], spawnPos, vehiclePrefabs[vehicleIndex].transform.rotation);
    }
}
