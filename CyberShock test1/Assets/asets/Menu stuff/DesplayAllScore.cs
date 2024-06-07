﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class DesplayAllScore : MonoBehaviour
{
    public GameObject ContentOBJ;
    public GameObject presetForScore;

    private string tempCheckChainge;
    public void Update(){
        if(tempCheckChainge != GetComponent<TMP_Text>().text)
        {
            tempCheckChainge = GetComponent<TMP_Text>().text;
            string nameOfFolder = GetComponent<TMP_Text>().text;
            string filepath = Application.dataPath+"/Resources/map-data/"+nameOfFolder+"/scores.json";
            foreach(Transform child in ContentOBJ.transform)
            {
                Destroy(child.gameObject);
            }
            if(File.Exists(filepath))
            {
                //get data out
                ScoreData dataWrapp = JsonUtility.FromJson<ScoreData>(ReadAsString(filepath));
                int[] sorted = dataWrapp.Scores;
                Array.Sort(sorted);
                Array.Reverse(sorted);

                foreach (var item in sorted)
                {
                    //add ze file to ze list :3
                    
                    GameObject newscoreObj = Instantiate(presetForScore,ContentOBJ.transform);
                    newscoreObj.GetComponent<TMP_Text>().text = "- "+item.ToString();
                   // Debug.Log(item);
                }
                List<int> addingAValueList = new List<int>(dataWrapp.Scores);
                Debug.Log(tempCheckChainge);
                
            }else{
                GameObject newscoreObj = Instantiate(presetForScore,ContentOBJ.transform);
                newscoreObj.GetComponent<TMP_Text>().text = "- No Scores... Yet";
            }
            
        }
        
    }
    private string ReadAsString(string filePath){
        string returnString = null;
        try
        {
            if(File.Exists(filePath))
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    //Debug.Log("Write to file:");
                    using (StreamReader reader = new StreamReader(stream)) 
                    {
                        Debug.Log("Write to file:");
                        returnString = reader.ReadToEnd();
                    }
                }
            }else{
                Debug.Log("NoScores");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            throw;
        }
        return returnString;
    }
    
}
