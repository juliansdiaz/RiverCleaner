using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public static GameObject hudCanvas, mainMenuCanvas, optionsCanvas, winUICanvas, loseUICanvas;

    void Start()
    {
        hudCanvas = transform.GetChild(0).gameObject;
        mainMenuCanvas = transform.GetChild(1).gameObject;
        optionsCanvas = transform.GetChild(2).gameObject;
        winUICanvas = transform.GetChild(3).gameObject;
        loseUICanvas = transform.GetChild(4).gameObject;
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

    public void ChangeMusicVolume()
    {
        AudioManager.Instance.MusicVolumeControl(musicSlider.value);
    }

    public void ChangeSFXVolume()
    {
        AudioManager.Instance.SFXVolumeControl(sfxSlider.value);
    }

    public void SaveOptions()
    {
        AudioManager.Instance.SaveSoundPreferences(musicSlider.value, sfxSlider.value);
    }

    public void LoadOptions()
    {
        AudioManager.Instance.LoadSoundPreferences(); // Carga los valores guardados en AudioManager
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.Instance.musicSavedValue); // Actualiza el slider de música
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.Instance.sfxSavedValue); // Actualiza el slider de efectos de sonido
    }

}
