using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] garbageObject;
    public Transform[] spawnPoints;
    public float spawnTime;
    public int spawnIndex;
    public int garbageIndex;
    public bool canSpawn = false;

    // Update is called once per frame
    void Update()
    {
        canSpawn = true;  
        SpawnGarbage(); 
    }

    void SpawnGarbage()
    {
        if(canSpawn)
        {
            spawnTime += Time.deltaTime; //Increase spawn time according to physics time
            if(spawnTime >= 5)
            {
                spawnIndex = Random.Range(0, spawnPoints.Length); //Select spawn point randomly
                garbageIndex = Random.Range(0, garbageObject.Length); //Select garbage item randomly
                Instantiate(garbageObject[garbageIndex], spawnPoints[spawnIndex].position, Quaternion.identity); //Instatiate random garbage item in selected spawn point
                spawnTime = 0; //reset spawn time
            }
        }
    }
}
