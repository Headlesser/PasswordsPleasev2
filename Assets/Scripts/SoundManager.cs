using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider musicSlider;

    public AudioSource[] soundEffects;
    public AudioSource[] musicTracks;

    [SerializeField] AudioMixer musicMixer;
    [SerializeField] AudioMixer sfxMixer;

    public void EditSFXVolume()
    {
        sfxMixer.SetFloat("SFXMasterVolume", sfxSlider.value);
    }

    public void EditMusicVolume()
    {
        musicMixer.SetFloat("MusicMasterVolume", musicSlider.value);
    }
}
