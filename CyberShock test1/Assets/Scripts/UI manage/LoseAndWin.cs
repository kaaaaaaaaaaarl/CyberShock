using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using static GameDificulty;

public class LoseAndWin : MonoBehaviour
{
    // Start is called before the first frame update
    static AudioSource AudioSource;
    public GameObject youLost;
    public GameObject youWon;
    public jsonreader reader;
    public OpenPause pauseController;
    
    private readonly string encryptionCodeWord = "word";
    private TextAsset textAsset = null;
    private bool hasSaved = false;
    private string filepath;
    void Start()
    {

        filepath = Application.dataPath+"/Resources/map-data/"+StaticObject.songName+"/scores.json";
        Debug.Log(File.Exists(filepath));
        AudioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        if(!youLost){
            youLost = GameObject.Find("Game over");
        }
        if(!youWon){
            youWon = GameObject.Find("win");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MapValues.damageTaken >= 1)
        {
            youLost.SetActive(true);
            pauseController.PauseGame();

        }else
        {
            youLost.SetActive(false);
        }
        if(reader.isEnded() && MapValues.damageTaken <= 1 && PlayerPrefs.GetInt("isPaused") !=1)
        {
            youWon.SetActive(true);
        }else
        {
            youWon.SetActive(false);
        }

        //saving the score
        if(!hasSaved && reader.isEnded() && MapValues.damageTaken <= 1 && PlayerPrefs.GetInt("isPaused") !=1){
            //check if the file exists or nah
            //a fucking mess:
            MakeFile();
            SaveToJson(ReadAsString());

            hasSaved = true;
        }
        
    }
    private static string Base64Encode(string plainText) 
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    private static string Base64Decode(string base64EncodedData) 
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    
    private void MakeFile()
    {
        try
        {
            if(!File.Exists(filepath))
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream)) 
                    {
                        Debug.Log("made a new file:");
                        writer.Write("my dick wont fall off");
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }
    

    private void WriteToFile(string stringToWrite){
        try
        {
            if(File.Exists(filepath))
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Open))
                {
                    //Debug.Log("Write to file:");
                    using (StreamWriter writer = new StreamWriter(stream)) 
                    {
                        Debug.Log("Write to file:");
                        writer.Write(stringToWrite);
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }
    private string ReadAsString(){
        string returnString = null;
        try
        {
            if(File.Exists(filepath))
            {
                using (FileStream stream = new FileStream(filepath, FileMode.Open))
                {
                    //Debug.Log("Write to file:");
                    using (StreamReader reader = new StreamReader(stream)) 
                    {
                        Debug.Log("Write to file:");
                        returnString = reader.ReadToEnd();
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            throw;
        }
        return returnString;
    }
    void SaveToJson(string str)
    {
        ScoreData dataWrapp = JsonUtility.FromJson<ScoreData>(str);
        List<int> addingAValueList = new List<int>(dataWrapp.Scores);
        addingAValueList.Add(MapValues.scorePoints);

        //make it back in to a json format after you scrushed it all up
        ScoreData newValues  = new ScoreData();
        newValues.Scores = addingAValueList.ToArray();

        string jsonToSave = JsonUtility.ToJson(newValues, true);
        foreach (var item in addingAValueList)
        {
            Debug.Log("item in arr: "+item);
        }
        Debug.Log(jsonToSave);
        WriteToFile(jsonToSave);
    }
}

[System.Serializable]
public class ScoreData
{
    public int[] Scores;
}