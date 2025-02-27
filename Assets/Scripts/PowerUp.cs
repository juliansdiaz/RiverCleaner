using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //Variables
    public static float timer = 20.0f;
    public static bool playerHasPowerUp = false;

    // Update is called once per frame
    void Update()
    {
        ManagePowerUpTimer();
    }

    public void ManagePowerUpTimer()
    {
        //Check if the player has the PowerUp active
        if(playerHasPowerUp == true)
        {
            timer -= 1.0f * Time.deltaTime; //Decreases the PowerUp timer
            
        }
        if(timer <= 0.0f)
        {
            timer = 20.0f; //Reset the PowerUp timer
            playerHasPowerUp = false; //Changes the PoweUp state
        }
    }
}
