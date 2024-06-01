using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = StaticObject.mainSong;
        if(audioSource.clip){
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
