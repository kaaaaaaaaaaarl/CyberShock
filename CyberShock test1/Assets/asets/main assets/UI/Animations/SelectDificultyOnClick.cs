﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDificultyOnClick : MonoBehaviour
{
    public TextAsset ButtonFileData;
    public bool selected;
    public void OnSelect()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<SelectDificultyOnClick>().selected = false;
        }
        selected = true;

        StaticObject.playableMapData = ButtonFileData;
        
    }
    void Update()
    {
        transform.Find("Image").gameObject.SetActive(selected);
    }
}
