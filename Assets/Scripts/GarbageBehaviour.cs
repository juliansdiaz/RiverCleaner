using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBehaviour : MonoBehaviour
{
    //Variables
    [SerializeField] float speed;
    [SerializeField] Transform destination;

    private void Start() 
    {
        destination = GameObject.Find("Destination").GetComponent<Transform>(); //Finds the Transform component of the Destination GameObject     
    }

    // Update is called once per frame
    void Update()
    {
        GarbageMovement(); //Call GarbageMovement method   
    }

    void GarbageMovement()
    {
        transform.position = Vector2.Lerp(transform.position, destination.position, speed * Time.deltaTime); //Move Garbage to Destination's position in the map
        
        //Destroy gameObject after reaching Destination position 
        if(Vector2.Distance(transform.position, destination.position) <= 3f)
        {
            Destroy(gameObject);
        }
    }
}
