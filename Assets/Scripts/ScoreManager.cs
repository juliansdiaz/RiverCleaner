using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}
    public float contaminationLvl = 10.0f;
    public float gameTime;
    [SerializeField] TextMeshProUGUI contaminationText;

    void Awake()
    {   
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("IncreaseContamination", 5f, 3.5f);
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if(contaminationLvl >= 100.0f)
        {
            GameManager.Instance.GameOverLose();
            contaminationLvl = 10.0f;
        }
        else if(contaminationLvl <= 0.0f)
        {
            GameManager.Instance.GameOverWin();
            contaminationLvl = 10.0f;
        }
    }

    void IncreaseContamination()
    {
        if(contaminationLvl < 100.0f && gameTime <= 30.0f)
        {
            contaminationLvl += 5.0f;
            contaminationText.text = "Contamination Level: " + contaminationLvl + "%";
        }
        else if(contaminationLvl < 100.0f  && gameTime >= 30.0f)
        {
            contaminationLvl += 10.0f;
            contaminationText.text = "Contamination Level: " + contaminationLvl + "%";
        }
    }   
}
