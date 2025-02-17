using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    [SerializeField] AudioSource sfxAudio, musicAudio;
    [SerializeField] AudioClip initialMusic;

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

    // Start is called before the first frame update
    void Start()
    {
        sfxAudio = transform.GetChild(0).GetComponent<AudioSource>();
        musicAudio = transform.GetChild(1).GetComponent<AudioSource>();
        PlayInitialMusic(initialMusic);
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
}
