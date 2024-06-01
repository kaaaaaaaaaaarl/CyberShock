using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider mainVolume;
    public Slider songSider;
    public Slider SFXSlider;
    static string SFX = "SFX";
    static string Music = "Music";
    static string Main = "main";

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Main", volume);
    }
    public void SetSfx (float volume)
    {
        audioMixer.SetFloat("SFX", volume);
    }
    public void SetMusic (float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }
    void Start(){
        SetVolume(PlayerPrefs.GetFloat(SFX));
        SetSfx(PlayerPrefs.GetFloat(Music));
        SetMusic(PlayerPrefs.GetFloat(Main));
        mainVolume.value = PlayerPrefs.GetFloat(Main);
        songSider.value = PlayerPrefs.GetFloat(Music);
        SFXSlider.value = PlayerPrefs.GetFloat(SFX);
    }
    void OnDisable()
    {
        PlayerPrefs.SetFloat(SFX, SFXSlider.value);
        PlayerPrefs.SetFloat(Music, songSider.value);
        PlayerPrefs.SetFloat(Main, mainVolume.value);
    }
    void Update(){
        audioMixer.SetFloat("Main", mainVolume.value);
        audioMixer.SetFloat("Music", songSider.value);
        audioMixer.SetFloat("SFX", SFXSlider.value);
        
    }
}
