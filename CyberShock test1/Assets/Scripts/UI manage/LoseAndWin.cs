using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static GameDificulty;

public class LoseAndWin : MonoBehaviour
{
    // Start is called before the first frame update
    static AudioSource AudioSource;
    public GameObject youLost;
    public GameObject youWon;
    public jsonreader reader;
    public OpenPause pauseController;
    public bool useEncryption = false;
    
    private readonly string encryptionCodeWord = "word";
    private TextAsset textAsset = null;
    private bool hasSaved = false;
    private string filepath;
    void Start()
    {
        filepath = Application.dataPath+"/Resources/map-data/"+StaticObject.songName+"/scores.json";
        Debug.Log(File.Exists(filepath));
        MakeFile();
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
            MakeFile();
            
            //a fucking mess:
            try 
            {
               // Directory.CreateDirectory(Path.GetDirectoryName(filepath));

                /*
                string dataToStore = JsonUtility.ToJson(data, true);
                if (useEncryption) 
                {
                    dataToStore = EncryptDecrypt(dataToStore);
                }
                */
            }
            catch (Exception e) 
            {
                Debug.LogError("Error occured when trying to save data to file: " + filepath + "\n" + e);
            }
/*
            //make new scores if does not exist
            if(!File.Exists("C:/Games/Cybershock/map-data/"))
            {
                System.IO.Directory.CreateDirectory("C:/Games/Cybershock/map-data/");
              //  File.Create("C:/Games/Cybershock/map-data/");
            }
            if(!File.Exists("C:/Games/Cybershock/map-data/"+StaticObject.songName)){
                resourcesDirectory = new DirectoryInfo("C:/Games/Cybershock/map-data/");
                File.Create(resourcesDirectory.ToString()+StaticObject.songName+ ".json");
                File.WriteAllText(resourcesDirectory.ToString()+StaticObject.songName+ ".json", "{\"Scores\": []}");
            }

            //add the score to the list:
            ScoreData dataWrapper = JsonUtility.FromJson<ScoreData>(
                File.ReadAllText("Resources/"+ StaticObject.songName+ "scores.json")
            );
            WriteScore(dataWrapper, resourcesDirectory.ToString()+"/map-data/"+StaticObject.songName);
            //to make sure this does not run 2 times in a row:
            hasSaved = true;
            */
        }
        
    }
    void WriteScore(ScoreData dataWrapper, string dir)
    {
        File.WriteAllText(dir, 
            (dataWrapper.Scores[dataWrapper.Scores.Length] = MapValues.scorePoints).ToString()
        );
    }
    private string EncryptDecrypt(string data) 
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++) 
        {
            modifiedData += (char) (data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
    private void MakeFile(){
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
}

[System.Serializable]
public class ScoreData
{
    public int[] Scores;
}