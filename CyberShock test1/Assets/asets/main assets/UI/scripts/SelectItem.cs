using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System;
public class SelectItem : MonoBehaviour
{
    public GameObject UIPrefab;
    public GameObject selectedButton;

    public TMP_Text textHolder;
    public Image imageHolder;
    public GameObject GameDificulty;
    void Start()
    {
        //gets the names of each folder
        DirectoryInfo dir = new DirectoryInfo(Application.streamingAssetsPath);
        dir = new DirectoryInfo(dir.Parent + "/Resources/Map-data");
        DirectoryInfo[] info = dir.GetDirectories();

        List<GameObject> contentPrefabs = new List<GameObject>();
        if(info.Length >0)
        {
           foreach (DirectoryInfo folderInfo in info) // Use foreach loop
            {
                GameObject newButton = Instantiate(UIPrefab, transform);
                try
                {
                    Button buttonComponent = newButton.GetComponent<Button>();

                    if (buttonComponent != null) // Ensure the component exists
                    {
                        int buttonIndex = contentPrefabs.Count - 1; // Store the index in a local variable
                        buttonComponent.onClick.AddListener(() => ButtonClicked(newButton));
                    }

                    TMP_Text m_TextComponent;
                    m_TextComponent = newButton.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
                    m_TextComponent.text = folderInfo.Name;
                }
                catch (System.Exception)
                {
                    Debug.Log("Map folder cant be found");
                    throw;
                }
                //image on UI
                try
                {
                    newButton.transform.Find("Image").GetComponent<Image>().sprite =
                    LoadNewSprite(dir + "/" + folderInfo.Name + "/Image.jpg");
                }
                catch (System.Exception)
                {
                    Debug.Log(folderInfo.Name + " image cant be found");
                    throw;
                }
                contentPrefabs.Add(newButton);
            }
            System.Random random = new System.Random();
            ButtonClicked(contentPrefabs[random.Next(0, contentPrefabs.Count)]); 
        }else
        {
            GameObject newButton = Instantiate(UIPrefab, transform);
        }
        

    }
    public void ButtonClicked(GameObject clickedButton)
    {
        selectedButton = clickedButton;
        // Access other components or properties as needed
        Text buttonText = clickedButton.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            Debug.Log("Button Text: " + buttonText.text);
        }
        textHolder.text = selectedButton.GetComponentInChildren<TMP_Text>().text;
        imageHolder.sprite = selectedButton.transform.Find("Image").GetComponentInChildren<Image>().sprite;

        GameDificulty.GetComponent<GameDificulty>().OnChainge();
    }
    //grabs the texture
    public Texture2D LoadTexture(string filePath)
    {
        Texture2D tex2D;
        byte[] fileData;
        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex2D = new Texture2D(2, 2);
            if (tex2D.LoadImage(fileData))
                return tex2D;
        }
        return null;
    }
    //makes a sprite from the texture
    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
    {
        Texture2D SpriteTexture = LoadTexture(FilePath);
        Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);
        return NewSprite;
    }
}