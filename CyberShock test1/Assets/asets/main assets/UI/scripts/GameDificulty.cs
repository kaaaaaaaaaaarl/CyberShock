using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDificulty : MonoBehaviour
{
    // public Image Image;
    public TMP_Text Text;
    public GameObject prefab;

    public void OnChainge(){
        StaticObject.playableMapData = null;
        string resourcesPath = Application.dataPath + "/Resources/Map-data/"+Text.text;
        DirectoryInfo resourcesDirectory = new DirectoryInfo(resourcesPath);
        FileInfo[] files = resourcesDirectory.GetFiles();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        foreach (FileInfo item in files)
        {
            if (item.Name.Contains(".json") && !item.Name.Contains(".meta")){

                TextAsset textAsset = Resources.Load("Map-data/" + Text.text + "/"+item.Name.Remove(item.Name.Length-5)) as TextAsset;
                

                if (textAsset != null)
                {
                    Debug.Log(textAsset);
                }
                else
                {
                    Debug.LogError("Failed to load JSON file: "+ "Map-data/"+Text.text + "/"+item.Name);
                }

                if(item.Name.Contains("mapData"))
                {
                    // Debug.Log("item is: "+ item.Name);
                    GameObject Button = Instantiate(prefab, this.transform);
                    string nameOfButton = item.Name.Remove(item.Name.Length-5);
                    
                    Button.GetComponentInChildren<TMP_Text>().text = nameOfButton.Remove(0, 8);
                    if(textAsset){
                        
                        GameData data = JsonUtility.FromJson<GameData>(textAsset.text);
                        Debug.Log(data.mapData[0].DificultyColor);
                        if (data.mapData != null && data.mapData.Length > 0 && data.mapData[0].DificultyColor != null && data.mapData[0].DificultyColor.Length > 0)
                        {
                            Button.GetComponentInChildren<Image>().color= HexToColor(data.mapData[0].DificultyColor);
                            Button.GetComponent<SelectDificultyOnClick>().ButtonFileData = textAsset;
                        }
                    }
                }
            
            }
        }
    }
    public static Color HexToColor(string hex)
    {
        // Check if the hex code is valid
        if (!ColorUtility.TryParseHtmlString(hex, out Color color))
        {
            Debug.LogWarning($"Invalid hexadecimal color string: '{hex}'. Using Color.white instead.");
            return Color.white; // Default to white on failure
        }

        return color;
    }
    [System.Serializable]
public class MapData
{
    public string DificultyColor;
}

[System.Serializable]
public class BeatMap
{
    public int BPM;
    public int[] arrows;
}

[System.Serializable]
public class GameData
{
    public MapData[] mapData;
    public BeatMap[] BeatMap;
}
    public static String ReadJson(TextAsset mapDataJson){
        GameData dataWrapper = JsonUtility.FromJson<GameData>(mapDataJson.text);
       

            MapData firstMapData = dataWrapper.mapData[0]; // Get the first map data entry
            Debug.Log(firstMapData);
            return dataWrapper.mapData[0].DificultyColor;

    }
}
