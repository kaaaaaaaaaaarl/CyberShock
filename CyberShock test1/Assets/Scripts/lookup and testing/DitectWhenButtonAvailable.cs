using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitectWhenButtonAvailable : MonoBehaviour
{
    public List<Collider> colliders = new List<Collider>();
    public List<Collider> GetColliders () { return colliders; }
    public GameObject particleHolder;
    private void OnTriggerEnter(Collider other)
    {
        if (!colliders.Contains(other)) { colliders.Add(other); }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Collider temp = other;
        colliders.Remove(temp);
        Destroy(temp.gameObject);
        particleHolder.GetComponent<numbers>().noPoints();
        
    }

    public void RemoveColider(Collider other){
       // colliders.FindIndex()
       // other.GetComponent<Collider>()
        colliders.Remove(other);
    }
}
