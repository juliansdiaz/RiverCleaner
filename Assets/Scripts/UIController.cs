using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Variables
    public Slider musicSlider, sfxSlider;
    public static GameObject hudCanvas, mainMenuCanvas, optionsCanvas, winUICanvas, loseUICanvas, creditsCanvas;

    void Start()
    {
        //Locate all available canvas
        hudCanvas = transform.GetChild(0).gameObject;
        mainMenuCanvas = transform.GetChild(1).gameObject;
        optionsCanvas = transform.GetChild(2).gameObject;
        winUICanvas = transform.GetChild(3).gameObject;
        loseUICanvas = transform.GetChild(4).gameObject;
        creditsCanvas = transform.GetChild(6).gameObject;

        mainMenuCanvas.SetActive(true); //Set mainMenuCanvas as active by default
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
        creditsCanvas.SetActive(false);
    }

    public static void ShowWinScreen()
    {
        hudCanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        winUICanvas.SetActive(true);
    }

    public static void ShowLoseScreen()
    {
        hudCanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        winUICanvas.SetActive(false);
        loseUICanvas.SetActive(true);
    }

    public void DisplayCredits()
    {
        hudCanvas.SetActive(false);
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        winUICanvas.SetActive(false);
        loseUICanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void ChangeMusicVolume()
    {
        AudioManager.Instance.MusicVolumeControl(musicSlider.value); //Update music volume according to Slider value
    }

    public void ChangeSFXVolume()
    {
        AudioManager.Instance.SFXVolumeControl(sfxSlider.value); //Update SFX volume according to Slider value
    }

    public void SaveOptions()
    {
        AudioManager.Instance.SaveSoundPreferences(musicSlider.value, sfxSlider.value); //Save player sound preferences
    }

    public void LoadOptions()
    {
        AudioManager.Instance.LoadSoundPreferences(); //Call LoadSoundPreferences method from GameManager
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.Instance.musicSavedValue); //Load saved Music value
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.Instance.sfxSavedValue); //Load saved sfx value
    }
}
