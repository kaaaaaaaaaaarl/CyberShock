using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    public jsonreader jsonreader;
    private float delay;
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = StaticObject.mainSong;
        
        Invoke("StartMusic", 2.0f + delay);
    }
    public void StartMusic(){
        if(audioSource.clip){
            audioSource.Play();
        }
    }
    void Update()
    {
        
    }
}
