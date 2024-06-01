using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPause : MonoBehaviour
{
    // Start is called before the first frame update
    static GameObject optionsMenu;
    static AudioSource AudioSource;
    public bool isPaused = false;
    void Start()
    {
        optionsMenu = GameObject.Find("Settings");
        AudioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        optionsMenu.SetActive(false);
        PlayerPrefs.SetInt("isPaused", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)){
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }
        if(optionsMenu.activeSelf){
            PlayerPrefs.SetInt("isPaused", 1);
            isPaused = true;
            AudioSource.Pause();
            Time.timeScale = 0;
        }else{
            PlayerPrefs.SetInt("isPaused", 0);
            isPaused = true;
            Time.timeScale = 1;
            AudioSource.UnPause();
        }
    }
}
