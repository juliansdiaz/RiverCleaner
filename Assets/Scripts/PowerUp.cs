using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static float timer = 20.0f;
    public static bool playerHasPowerUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManagePowerUpTimer();
    }

    public void ManagePowerUpTimer()
    {
        if(playerHasPowerUp == true)
        {
            timer -= 1.0f * Time.deltaTime;
            
        }
        if(timer <= 0.0f)
        {
            timer = 20.0f;
            playerHasPowerUp = false;
        }
    }
}
