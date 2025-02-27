using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //Variables
    public static AudioManager Instance {get; private set;}
    [SerializeField] AudioSource sfxAudio, musicAudio;
    [SerializeField] AudioClip initialMusic;
    [SerializeField] AudioMixer master;
    public string musicSavedValue = "musicValue";
    public string sfxSavedValue = "sfxValue";

    void Awake()
    {
        //Check if there isn't any AudioManager instance in the runtime and creates a new one
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); //Prevents AudioManager from being destroyed during runtime
        }
        else 
        {       
            Destroy(this.gameObject); //Destroys AudioManager GameObject if there's already an instance
        }
    }

    void Start()
    {
        sfxAudio = transform.GetChild(0).GetComponent<AudioSource>(); //Gets the AudioSource component from the first child Gameobject
        musicAudio = transform.GetChild(1).GetComponent<AudioSource>(); //Gets the AudioSource component from the second child Gameobject
        PlayInitialMusic(initialMusic); //Plays the initial background music
        LoadSoundPreferences(); //Loads the latest player sound preferences
    }  

    public void PlaySFX(AudioClip clip)
    {   
        sfxAudio.PlayOneShot(clip); //Plays SFX clip
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicAudio.Stop(); //Stops the current music clip
        musicAudio.clip = musicClip; //Sets the next music clip as the current clip
        musicAudio.Play(); //Play the current clip
        musicAudio.loop = true; //Set clip to loop
    }

    void PlayInitialMusic(AudioClip initialMusicClip)
    {
        musicAudio.clip = initialMusicClip; //Sets the selected music clip as the initial music
        musicAudio.Play(); //Play music clip
        musicAudio.loop = true; //Set clip to loop
    }

    public void MusicVolumeControl(float volume)
    {
        master.SetFloat("Music", volume); //Changes music volume according to AudioMixer value
    }

    public void SFXVolumeControl(float volume)
    {
        master.SetFloat("SFX", volume); //Changes SFX volume according to AudioMixer value
    }

    public void SaveSoundPreferences(float levelMusic, float levelSFX)
    {
        PlayerPrefs.SetFloat(musicSavedValue, levelMusic); //Saves the selected music volume
        PlayerPrefs.SetFloat(sfxSavedValue, levelSFX); //Saves the selected SFX volume
    }

    public void LoadSoundPreferences()
    {
        //Check if player has saved music and SFX volume values
        if (PlayerPrefs.HasKey(musicSavedValue))
        {
            MusicVolumeControl(PlayerPrefs.GetFloat(musicSavedValue)); //Loads music volume
        }   SFXVolumeControl(PlayerPrefs.GetFloat(sfxSavedValue)); //Loads SFX volume
    }
}
