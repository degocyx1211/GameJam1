using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioSource[] music;
    public AudioSource[] soundEfectsEFX;

    public AudioMixerGroup musicMixer, sfxMixer;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic(int musicToPlay)
    {
        music[musicToPlay].Play();
    }

    public void StopMusic(int musicToPlay)
    {
        music[musicToPlay].Stop();
    }

    public void PlaySFX(int sfxPlay)
    {
        soundEfectsEFX[sfxPlay].Play();
    }

    public void StopSFX(int sfxPlay)
    {
        soundEfectsEFX[sfxPlay].Stop();
    }

    //public void SetMusicLevel()
    //{
    //    musicMixer.audioMixer.SetFloat("MusicVol", UIController.instance.musicVolSlider.value);
    //}

    //public void SetSFXLevel()
    //{
    //    sfxMixer.audioMixer.SetFloat("SFXVol", UIController.instance.sfxVolSlider.value);
    //}
}