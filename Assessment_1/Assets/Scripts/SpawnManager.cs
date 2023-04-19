using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] GameObjectPrefabs;
    private float spawnPosY = 30;
    private float spawnRangeX = 9;
    private float startDelay = 9;
    private float spawnInterval = 1f;
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomGameObject", startDelay, spawnInterval);

    }
    // Update is called once per frame
    void Update()
    {
       
    }
   
    void SpawnRandomGameObject()
    {
        // Set random spawn location and random object index

        int GameObject = Random.Range(0, GameObjectPrefabs.Length);
        
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);
       


        Instantiate(GameObjectPrefabs[GameObject], spawnPos, GameObjectPrefabs[GameObject].transform.rotation);
    }
}
