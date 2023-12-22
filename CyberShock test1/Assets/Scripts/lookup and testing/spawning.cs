using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject rightPrefab;
    public GameObject leftPrefab;
    public GameObject upPrefab;
    public float spawnTime = 1.0f;
    public bool spawnRight = false;
    public bool spawnLeft = false;
    public bool spawnUP = false;

    float _time = 1f;
     float _interval = 3f;
    public void spawnArrows(int position)
    {
        switch (position)
        {
            case 1: 
                {
                    GameObject a = Instantiate(rightPrefab) as GameObject;
                    a.transform.SetParent(this.transform);
                    a.transform.position = new Vector3(15f, -10f, 15f);
                    break;
                }
            case 2: 
                {
                    GameObject a = Instantiate(leftPrefab) as GameObject;
                    a.transform.SetParent(this.transform);
                    a.transform.position = new Vector3(19f, -10f, 15f);
                    break;
                    
                }
            case 3:
                {
                    GameObject a = Instantiate(upPrefab) as GameObject;
                    a.transform.SetParent(this.transform);
                    a.transform.position = new Vector3(17f,-10f, 15f);
                    break;

                }
            default:
                {
                    break;
                }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

        if (spawnRight)
        {
            spawnArrows(1);
            spawnRight = false;
        }
        if (spawnLeft)
        {
            spawnArrows(2);
            spawnLeft = false;
        }
        if (spawnUP)
        {
            spawnArrows(3);
            spawnUP = false;
        }
    }
}
