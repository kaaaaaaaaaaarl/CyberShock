using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CheckInput : MonoBehaviour
{
    public GameObject sensor;
    public GameObject particleHolder; 
    //defines all the values at the begining
    void Start(){
        if(sensor){
            sensor = gameObject;
        }
        if(particleHolder){
            particleHolder = GameObject.Find("particle Holder");
        }
    }
    //all inputs
    public void UP(InputAction.CallbackContext context){
        OnPress(context, "up");
    }
    public void Space(InputAction.CallbackContext context){
        OnPress(context, "space");
    }
    public void Right(InputAction.CallbackContext context){
        OnPress(context, "right");
        
    }
    public void Left(InputAction.CallbackContext context){
        OnPress(context, "left");
    }
    //shortening code:
    void OnPress(InputAction.CallbackContext context, string position){
        string type = "singlePress";
        if(context.performed)
        {
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
        }else if(Math.Abs(distance) >=0.6 && Math.Abs(distance) <=1.2)
        {
            MapValues.scorePoints += 200;
            particleHolder.GetComponent<numbers>().midPoints();
        }else if(Math.Abs(distance) >=0 && Math.Abs(distance) <=0.6)
        {
            MapValues.scorePoints += 300;
            particleHolder.GetComponent<numbers>().highPoints();
        }
    }
}