using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCatchButton : MonoBehaviour
{
    GameObject rightRay,leftRay,middleRay;

    float speedValue;
    void Start(){
        rightRay = GameObject.Find("CatchRight");
        leftRay = GameObject.Find("CatchLeft");
        middleRay = GameObject.Find("CatchMiddle");
        
    }
    public int GetAccuracyRating(float timeDif){
        int totalValue = 0;

        
        18f /speed

        return totalValue;;
    }
    public GameObject FindArrowInLane(string direction){
        float raycastDistance = 4f;
        RaycastHit hit;
        switch (direction)
        {
            case "right":
                Debug.DrawRay(rightRay.transform.position, transform.forward * raycastDistance, Color.red);
                if (Physics.Raycast(rightRay.transform.position, transform.forward, out hit, raycastDistance))
                {
                    Debug.Log("Forward raycast hit: " + hit.collider.gameObject.name);
                }

            return hit.collider.gameObject;
            
            case "left":
                Debug.DrawRay(leftRay.transform.position, transform.forward * raycastDistance, Color.red);
                if (Physics.Raycast(leftRay.transform.position, transform.forward, out hit, raycastDistance))
                {
                    Debug.Log("Forward raycast hit: " + hit.collider.gameObject.name);
                }

            return hit.collider.gameObject;

            case "middle":
                Debug.DrawRay(middleRay.transform.position, transform.forward * raycastDistance, Color.red);
                if (Physics.Raycast(middleRay.transform.position, transform.forward, out hit, raycastDistance))
                {
                    Debug.Log("Forward raycast hit: " + hit.collider.gameObject.name);
                }

            return hit.collider.gameObject;
            
            default:
            return null;
        }
        
    }

    void CheckNoteAccuracy(string direction) 
    {
        // 1. Find the relevant arrow (using raycast, position comparison, etc.)
        GameObject arrowToCheck = FindArrowInLane(direction); 

        if (arrowToCheck != null) 
        {
            
            // 2. Calculate time difference
            float timeDiff = arrowToCheck.GetComponent<OnSpawnMove>().TargetTime();
            /*
            // 3. Determine accuracy 
            int accuracy = GetAccuracyRating(timeDiff);

            // 4. Handle feedback (this will likely be more complex)
            Debug.Log("Accuracy: " + accuracy);
            Destroy(arrowToCheck);
            */
        }
    }
    public void OnRightKeyPressed() 
    {
        if (Input.GetButtonDown("Horizontal_right") && Input.GetAxis("Horizontal_right") > 0) // Check if the button was pressed 
        {
            CheckNoteAccuracy("right");
        }
    }
    // Update is called once per frame
    void Update()
    {
        float raycastDistance = 2.5f;
        RaycastHit hit;
        Debug.DrawRay(rightRay.transform.position, transform.forward * raycastDistance, Color.red);
        if (Physics.Raycast(rightRay.transform.position, transform.forward, out hit, raycastDistance) || Physics.Raycast(leftRay.transform.position, transform.forward, out hit, raycastDistance) || Physics.Raycast(middleRay.transform.position, transform.forward, out hit, raycastDistance))
        {
            Debug.Log("land: "+Time.time);
        }
    }
}