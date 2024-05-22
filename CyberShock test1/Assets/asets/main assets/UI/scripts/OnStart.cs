using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStart : MonoBehaviour
{
    public void OnClick(){
        if(StaticObject.playableMapData){
            SceneManager.LoadScene("Gameplay");
            MapValues.scorePoints = 0;
        }
    }
}
