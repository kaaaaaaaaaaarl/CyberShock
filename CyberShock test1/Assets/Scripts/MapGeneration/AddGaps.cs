using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class AddGaps : MonoBehaviour
{
    // Start is called before the first frame update
    public string originalDir;
    public string newDir;
    public int gapCount;
    public TMP_Text tmp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStart()
    {
        originalDir = Application.dataPath+"/Resources/mapModer/" + originalDir;
        newDir = Application.dataPath+"/Resources/mapModer/" + newDir;
        string originalJson = ReadAsString(originalDir);
        MakeFile(newDir);
        string newJson = SaveToJson(gapCount, originalJson, newDir);
        tmp.text = newJson;
    }
    private void MakeFile(string filepath)
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
                        writer.Write("");
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
    private string ReadAsString(string filePath)
    {
        string returnString = null;
        try
        {
            if (File.Exists(filePath))
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        returnString = reader.ReadToEnd();
                    }
                }
            }
            else
            {
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
    private void WriteToFile(string stringToWrite, string filePath){
        try
        {
            if(File.Exists(filePath))
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
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
    private string SaveToJson(int gapCount, string jsonVal, string newDir)
    {
        string returnString = "";

        PlayerList oldData = JsonUtility.FromJson<PlayerList>(jsonVal);
        foreach (var item in oldData.BeatMap[0].arrows)
        {
          //  Debug.Log("item in arr: "+item);
            returnString = returnString + item.ToString() + ", ";

        }
        //delete all old values 1st
        PlayerList newData = oldData;
                             // newData.BeatMap[0].arrows = [];
        //setNewValues
        List<int> addingAValueList = new List<int>();
        foreach (var item in oldData.BeatMap[0].arrows)
        {
            addingAValueList.Add(item);
            for (int i = 0; i < gapCount; i++)
            {
                addingAValueList.Add(6000);
            }
            //Debug.Log("item in arr: "+item);
        }
        newData.BeatMap[0].arrows = addingAValueList.ToArray();
        string jsonToSave = JsonUtility.ToJson(newData, true);
        WriteToFile(jsonToSave, newDir);
        return jsonToSave;
        /*

        List<int> addingAValueList = new List<int>(dataWrapp.Scores);
        //addingAValueList.Add(MapValues.scorePoints);

        //make it back in to a json format after you scrushed it all up
        Player newValues  = new Player();
        newValues.arrows = addingAValueList.ToArray();

        string jsonToSave = JsonUtility.ToJson(newValues, true);

        
        //Debug.Log(jsonToSave);
        WriteToFile(jsonToSave, newDir);
        
        */
    }

    [System.Serializable]

    public class Player
    {
        public int BPM;
        public int speed;
        public int[] arrows;
    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] BeatMap;
    }
    // public PlayerList myPLayerList = new PlayerList();
    
}
