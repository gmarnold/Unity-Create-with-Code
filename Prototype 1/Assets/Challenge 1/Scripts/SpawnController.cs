using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] carPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        int interval = Random.Range(2, 5);
        InvokeRepeating("SpawnCar", 1, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCar()
    {
        int carIndex = Random.Range(0, carPrefabs.Length);
        int carPosX = Random.Range(-8, 8);
        Instantiate(carPrefabs[carIndex], new Vector3(carPosX, 0, 180), carPrefabs[carIndex].transform.rotation);
        // x: -8, 8; y: 0, z: 180
    }
}
