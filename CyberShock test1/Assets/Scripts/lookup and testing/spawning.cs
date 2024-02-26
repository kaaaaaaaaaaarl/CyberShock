using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawning : MonoBehaviour
{
    public GameObject rightPrefab;
    public GameObject leftPrefab;
    public GameObject upPrefab;
    public float spawnTime = 1.0f;
    public bool spawnRight = false;
    public bool spawnLeft = false;
    public bool spawnUP = false;
    public List<GameObject> allArrows;

    float timePassed = 0f;
     float _interval = 3f;
    public void spawnArrows(int position)
    {
        switch (position)
        {
            case 1: 
                {
                    GameObject a = Instantiate(rightPrefab) as GameObject;
                    a.transform.SetParent(this.transform);
                    allArrows.Add(a);
                    a.transform.position = new Vector3(15f, -10f, 15f);
                    break;
                }
            case 2: 
                {
                    GameObject a = Instantiate(leftPrefab) as GameObject;
                    a.transform.SetParent(this.transform);
                    allArrows.Add(a);
                    a.transform.position = new Vector3(19f, -10f, 15f);
                    break;
                    
                }
            case 3:
                {
                    GameObject a = Instantiate(upPrefab) as GameObject;
                    a.transform.SetParent(this.transform);
                    allArrows.Add(a);
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
        if (spawnTime <0.1f) {
            spawnTime = 0.1f;
        }
        /*
        timePassed += Time.deltaTime;
        if (timePassed > spawnTime)
        {
            //do something
            spawnArrows(1);
            timePassed = 0f;
        }
        */
    }

    public void DestroyLast()
    {   if (allArrows.Last() != null)
        {
        //    Debug.Log(allArrows.Last());
            Destroy(allArrows.Last());
        }
    }
    }
