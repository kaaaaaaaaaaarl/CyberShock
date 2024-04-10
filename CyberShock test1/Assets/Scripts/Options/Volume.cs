using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer audioMixer;

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
}
