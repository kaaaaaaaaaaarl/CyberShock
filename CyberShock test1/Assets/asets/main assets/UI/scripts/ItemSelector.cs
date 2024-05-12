using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public GameObject contentHolder;
    public GameObject showCase;

    void Start()
    {
        GetAllChildren(contentHolder);
        GetAllChildren(showCase);
    }
    
    private Transform[] GetAllChildren(GameObject parent){
        Transform[] Children = new Transform[parent.transform.childCount];
        try
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                Children[i] = parent.transform.GetChild(i);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
            return null;
        }
        
        return Children;
    }
    
}
