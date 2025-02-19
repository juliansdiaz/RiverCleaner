using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public static GameObject hudCanvas, mainMenuCanvas, optionsCanvas;

    void Start()
    {
        hudCanvas = transform.GetChild(0).gameObject;
        mainMenuCanvas = transform.GetChild(1).gameObject;
        optionsCanvas = transform.GetChild(2).gameObject;
    }

    public void PlayGame()
    {
        hudCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        GameManager.Instance.StartGame();
    }

    public void OpenOptionsMenu()
    {
        mainMenuCanvas.SetActive(false);
        hudCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        hudCanvas.SetActive(false);
    }


}
