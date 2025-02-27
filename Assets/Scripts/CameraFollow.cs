using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables
    Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform; //Finds the player withing the hierarchy
    }

    void LateUpdate() 
    {   
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z); //Update camera position according to player position
    }
}
