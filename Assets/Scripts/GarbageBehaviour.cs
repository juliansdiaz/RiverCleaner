using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform destination;

    private void Start() 
    {
        destination = GameObject.Find("Destination").GetComponent<Transform>();     
    }

    // Update is called once per frame
    void Update()
    {
        GarbageMovement();       
    }

    void GarbageMovement()
    {
        transform.position = Vector2.Lerp(transform.position, destination.position, speed * Time.deltaTime);
         //Destroy gameObject after reaching desired position 
        if(Vector2.Distance(transform.position, destination.position) <= 3f)
        {
            Destroy(gameObject);
        }
    }
}
