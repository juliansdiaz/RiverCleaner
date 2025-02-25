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
    public float gameTime; 

    // Update is called once per frame
    void Update()
    {
        canSpawn = true;
        SpawnGarbage();
        gameTime += Time.deltaTime;
    }

    void SpawnGarbage()
    {
        if (canSpawn && gameTime <= 30.0f)
        {
            spawnTime += Time.deltaTime; //Increase spawn time according to physics time
            if (spawnTime >= 4.5f && PowerUp.playerHasPowerUp == false)
            {
                spawnIndex = Random.Range(0, spawnPoints.Length); //Select spawn point randomly
                garbageIndex = Random.Range(0, garbageObject.Length); //Select garbage item randomly
                Instantiate(garbageObject[garbageIndex], spawnPoints[spawnIndex].position, Quaternion.identity); //Instatiate random garbage item in selected spawn point
                spawnTime = 0; //reset spawn time
            }
            else if (spawnTime >= 4.5f && PowerUp.playerHasPowerUp == true)
            {
                spawnIndex = Random.Range(0, spawnPoints.Length); //Select spawn point randomly
                garbageIndex = Random.Range(0, 2); //Exclude powerUp item from spawn items
                Instantiate(garbageObject[garbageIndex], spawnPoints[spawnIndex].position, Quaternion.identity); //Instatiate random garbage item in selected spawn point
                spawnTime = 0; //reset spawn time
            }
        }
        else if (canSpawn && gameTime >= 30.0f)
        {
            if (spawnTime >= 2.5f && PowerUp.playerHasPowerUp == false)
            {
                spawnIndex = Random.Range(0, spawnPoints.Length); //Select spawn point randomly
                garbageIndex = Random.Range(0, garbageObject.Length); //Select garbage item randomly
                Instantiate(garbageObject[garbageIndex], spawnPoints[spawnIndex].position, Quaternion.identity); //Instatiate random garbage item in selected spawn point
                spawnTime = 0; //reset spawn time
            }
            else if (spawnTime >= 2.5f && PowerUp.playerHasPowerUp == false)
            {
                spawnIndex = Random.Range(0, spawnPoints.Length); //Select spawn point randomly
                garbageIndex = Random.Range(0, 2); //Exclude powerUp item from spawn items
                Instantiate(garbageObject[garbageIndex], spawnPoints[spawnIndex].position, Quaternion.identity); //Instatiate random garbage item in selected spawn point
                spawnTime = 0; //reset spawn time
            }
        }
    }
}
