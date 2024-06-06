using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPause : MonoBehaviour
{
    // Start is called before the first frame update
    static GameObject optionsMenu;
    static GameObject settingsMenu;
    static AudioSource AudioSource;
    public bool isPaused = false;
    void Start()
    {
        optionsMenu = GameObject.Find("Pause Menu");
        settingsMenu = GameObject.Find("Settings");

        AudioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        optionsMenu.SetActive(false);
        PlayerPrefs.SetInt("isPaused", 0);
    }
    public void PauseGame()
    {
        PlayerPrefs.SetInt("isPaused", 1);
       // isPaused = true;
        AudioSource.Pause();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && MapValues.damageTaken<=1){
            isPaused = !isPaused;
            optionsMenu.SetActive(isPaused);
            if(!isPaused){
                settingsMenu.SetActive(false);
            }   
        }
        if(isPaused){
            PlayerPrefs.SetInt("isPaused", 1);
           // isPaused = true;
            AudioSource.Pause();
            Time.timeScale = 0;
        }
        if(MapValues.damageTaken<=1 && !isPaused){
            PlayerPrefs.SetInt("isPaused", 0);
           // isPaused = true;
            Time.timeScale = 1;
            AudioSource.UnPause();
        }
        
    }
}
