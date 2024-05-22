using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpawnMove : MonoBehaviour
{
    public float speed; 
    public float movementDistance = 30f; 
    float spawnInTime;
    public bool isAlive = true;

    private float initialZ;

    void Start()
    {
        speed = GameObject.Find("Script holder").GetComponent<jsonreader>().GetSpeed();
        initialZ = transform.position.z;
        spawnInTime = Time.time;
        //Debug.Log("Predicted Time: "+TargetTime());
    }

    public float TargetTime(){
        float timeDifference = 18f /speed;
        return (timeDifference + spawnInTime);
    }
    void Update()
    {
        // Moves the object along the X-axis at the specified speed
        transform.position += new Vector3(0f, 0f, speed * -1f * Time.deltaTime);

        // Check if distance limit has been reached
        if (Mathf.Abs(transform.position.z - initialZ) >= movementDistance)
        {
            Destroy(gameObject);
        }
    }
}
