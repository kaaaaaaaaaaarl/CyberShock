using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpawnMove : MonoBehaviour
{
    public float speed = 5f; 
    public float movementDistance = 30f; 


    private float initialZ;

    void Start()
    {
        initialZ = transform.position.z;
    }

    void Update()
    {
        float direction = -1f; // Determines if moving right or left

        // Moves the object along the X-axis at the specified speed
        transform.position += new Vector3(0f, 0f, speed * direction * Time.deltaTime);

        // Check if distance limit has been reached
        if (Mathf.Abs(transform.position.z - initialZ) >= movementDistance)
        {
            Destroy(gameObject); // You can replace this with other actions if desired
        }
    }
}
