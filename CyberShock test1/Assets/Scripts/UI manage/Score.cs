using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
   // public new List<TMP_Text> scores;
    public TMP_Text[] scores;
    void Start()
    {

        foreach (var scoreGameObject in scores)
        {
            scoreGameObject.text = "Score: "+ "0";
        }
        
    }
    void Update()
    {
        foreach (var scoreGameObject in scores)
        {
            scoreGameObject.text = "Score: "+ MapValues.scorePoints.ToString();
        }
    }
}
