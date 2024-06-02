﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckInput : MonoBehaviour
{
    public GameObject sensor;
    public GameObject particleHolder; 
    bool isPaused;
    //defines all the values at the begining
    void Start(){
        if(sensor){
            sensor = gameObject;
        }
        if(particleHolder){
            particleHolder = GameObject.Find("Particle Holder");
        }
        Debug.Log(PlayerPrefs.GetInt("isPaused"));
    }
    //all inputs
    /*
    public void UP(InputAction.CallbackContext context){
        OnPress(context, "up");
        Debug.Log("up");
    }
    public void Space(InputAction.CallbackContext context){
        OnPress(context, "space");
        Debug.Log("space");
    }
    public void Right(InputAction.CallbackContext context){
        OnPress(context, "right");
        Debug.Log("right");
        
    }
    public void Left(InputAction.CallbackContext context){
        OnPress(context, "left");
        Debug.Log("left");
    }
    */
    void Update(){
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            OnPress("up");
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            OnPress("left");
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            OnPress("right");
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            OnPress("space");
        }
    }
    //shortening code:
    void OnPress(string position){
        if(PlayerPrefs.GetInt("isPaused") == 0){

            string type = "singlePress";
            GameObject arrow = DisregardArrows(CheckLocation(position));
            if(arrow){
                switch (type)
                {
                    case "singlePress":
                        PointCalculator(arrow);
                        Deleteer(arrow);
                        break;
                    case "longPress":
                        PointCalculator(arrow);
                        Deleteer(arrow);
                        break;
                    default:

                    break;
                }
                
            }else{
                particleHolder.GetComponent<numbers>().noPoints();
            }
        }
    }

    //==============================================================================================================

    //Remove from list and remove from world at the same time
    void Deleteer(GameObject obj){
        Collider tempp = obj.GetComponent<Collider>();
        gameObject.GetComponent<DitectWhenButtonAvailable>().RemoveColider(tempp);
        UnityEngine.Object.Destroy(obj);
    }

    //Check if the direction is correct
    private List<GameObject> CheckLocation(string direction){
        List<GameObject> available = new List<GameObject>();
        List<Collider> coliders = sensor.GetComponent<DitectWhenButtonAvailable>().GetColliders();

        foreach (Collider colider in coliders)
        {
            if(colider.gameObject.GetComponent<ArrowType>().directon == direction)
            {
                available.Add(colider.gameObject);
                
            }
        }
        return available;
    }

    //check if any arrows need to be disregarded
    private GameObject DisregardArrows(List<GameObject> arrows)
    {
        GameObject availableBTN = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (GameObject obj in arrows)
        {
            Vector3 directionToTarget = obj.transform.position - transform.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                availableBTN = obj;
            }else // Change the tag of non-closest objects
            {
                if(obj.transform.position.y < transform.position.y){
                    obj.tag = "Late";
                }
            }
        }
        return availableBTN;
    }
    
    //Determine how many points the click was worth
    private void PointCalculator(GameObject obj){
        //math aka meth
        float distance = transform.position.z - obj.transform.position.z;
        if (Math.Abs(distance) >=1.2)
        {
            MapValues.scorePoints += 100;
            particleHolder.GetComponent<numbers>().lowPoints();
        }else if(Math.Abs(distance) >=0.3 && Math.Abs(distance) <=1)
        {
            MapValues.scorePoints += 200;
            particleHolder.GetComponent<numbers>().midPoints();
        }else if(Math.Abs(distance) >=0 && Math.Abs(distance) <=0.3)
        {
            MapValues.scorePoints += 300;
            particleHolder.GetComponent<numbers>().highPoints();
        }
    }
}