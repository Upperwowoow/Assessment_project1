using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //gameobject/gameobjectprefabs
    public GameObject[] GameObjectPrefabs;
    //the spawn range on the y axis
    private float spawnPosY = 130;
    //the spawn range on the x axis
    private float spawnRangeX = 9;
    //the delay of the spawn 
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
        //the spawn range of the x and set the where it spawn on the y axis 
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);
       


        Instantiate(GameObjectPrefabs[GameObject], spawnPos, GameObjectPrefabs[GameObject].transform.rotation);
    }
}
