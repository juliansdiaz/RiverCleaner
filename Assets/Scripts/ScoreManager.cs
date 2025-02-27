using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Variables
    public static ScoreManager Instance {get; private set;}
    public float contaminationLvl = 10.0f;
    public float gameTime;
    [SerializeField] TextMeshProUGUI contaminationText;

    void Awake()
    {   
        //Check if there isn't any ScoreManager instance in the runtime and creates a new one
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject); //Destroys ScoreManager GameObject if there's already an instance
        }
    }

    void Start()
    {
        InvokeRepeating("IncreaseContamination", 5f, 3.5f); //Call IncreaseContamination method according to parameters
    }

    void Update()
    {
        gameTime += Time.deltaTime; //Keep record of game time

        //Check if contaminationLvl has reached desired value
        if(contaminationLvl >= 100.0f)
        {
            GameManager.Instance.GameOverLose(); //Call GameOverLoseMethod from GameManager
            contaminationLvl = 10.0f; //Reset contaminationLvl value to default
        }
        //Check if contaminationLvl has reached desired value
        else if(contaminationLvl <= 0.0f)
        {
            GameManager.Instance.GameOverWin(); //Call GameOverWinMethod from GameManager
            contaminationLvl = 10.0f; //Reset contaminationLvl value to default
        }
    }

    void IncreaseContamination()
    {
        if(contaminationLvl < 100.0f && gameTime <= 30.0f)
        {
            contaminationLvl += 5.0f; //Increase contamination value by 5
            contaminationText.text = "Contamination Level: " + contaminationLvl + "%"; //Display contamination value on screen
        }
        else if(contaminationLvl < 100.0f  && gameTime >= 30.0f)
        {
            contaminationLvl += 10.0f; //Increase contamination value by 10
            contaminationText.text = "Contamination Level: " + contaminationLvl + "%"; //Display contamination value on screen
        }
    }   
}
