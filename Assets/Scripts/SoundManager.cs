using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider musicSlider;

    public AudioSource[] soundEffects;
    public AudioSource[] musicTracks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EditSFXVolume()
    {
        foreach(AudioSource sfx in soundEffects)
        {
            sfx.volume = sfxSlider.value;
        }
    }

    public void EditMusicVolume()
    {
        foreach (AudioSource track in musicTracks)
        {
            track.volume = musicSlider.value;
        }
    }
}
