using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public TMP_Text scores;
    public RawImage healthbarImage; 

    void Update()
    {
            // Debug.Log(MapValues.damageTaken);
            healthbarImage.uvRect = new Rect(MapValues.damageTaken, healthbarImage.uvRect.y, healthbarImage.uvRect.width, healthbarImage.uvRect.height);
        
        //scores.text = MapValues.scorePoints.ToString();
    }
}