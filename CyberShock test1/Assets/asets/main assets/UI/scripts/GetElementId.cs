using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetElementId : MonoBehaviour
{
    // public bool[] selectedOBJIndex;
    public GameObject selectedOBJ;
    public void ClickEvent(GameObject selected){
        selectedOBJ = selected;
    }
    void Start(){
        //selectedOBJ = new bool[this.transform.childCount];
    }
}
