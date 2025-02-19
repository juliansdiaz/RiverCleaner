using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    [SerializeField] AudioSource sfxAudio, musicAudio;
    [SerializeField] AudioClip initialMusic;
    [SerializeField] AudioMixer master;
    public string musicSavedValue = "musicValue";
    public string sfxSavedValue = "sfxValue";

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {       
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sfxAudio = transform.GetChild(0).GetComponent<AudioSource>();
        musicAudio = transform.GetChild(1).GetComponent<AudioSource>();
        PlayInitialMusic(initialMusic);
        LoadSoundPreferences();
    }  

    public void PlaySFX(AudioClip clip)
    {   
        sfxAudio.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicAudio.Stop();
        musicAudio.clip = musicClip;
        musicAudio.Play();
        musicAudio.loop = true;
    }

    void PlayInitialMusic(AudioClip initialMusicClip)
    {
        musicAudio.clip = initialMusicClip;
        musicAudio.Play();
        musicAudio.loop = true;
    }

    public void MusicVolumeControl(float volume)
    {
        master.SetFloat("Music", volume);
    }

    public void SFXVolumeControl(float volume)
    {
        master.SetFloat("SFX", volume);
    }

    public void SaveSoundPreferences(float levelMusic, float levelSFX)
    {
        PlayerPrefs.SetFloat(musicSavedValue, levelMusic);
        PlayerPrefs.SetFloat(sfxSavedValue, levelSFX);
    }

    public void LoadSoundPreferences()
    {
        if (PlayerPrefs.HasKey(musicSavedValue))
        {
            MusicVolumeControl(PlayerPrefs.GetFloat(musicSavedValue));
        }   SFXVolumeControl(PlayerPrefs.GetFloat(sfxSavedValue)); 
    }


}
