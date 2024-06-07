using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCatchButton : MonoBehaviour
{
    GameObject rightRay, leftRay, middleRay;

    float speedValue;
    void Start()
    {
        rightRay = GameObject.Find("CatchRight");
        leftRay = GameObject.Find("CatchLeft");
        middleRay = GameObject.Find("CatchMiddle");

    }
    public int GetAccuracyRating(float timeDif)
    {
        int totalValue = 0;
        // 18f /speed;
        return totalValue; ;
    }
    public GameObject FindArrowInLane(string direction)
    {
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
            case "space":
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
}