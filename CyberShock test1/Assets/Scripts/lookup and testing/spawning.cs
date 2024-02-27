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

    public void DestroyLast(int arrowIndex)
        {   
            string objNameSelect;
            GameObject temp;
            switch (arrowIndex)
            { 
                case 0:
                    objNameSelect = "right arrow(Clone)";
                    break;
                case 1:
                    objNameSelect = "left arrow(Clone)";
                    break;
                case 2:
                    objNameSelect = "up arrow(Clone)";
                    break;
                default:
                    objNameSelect = null;
                    break;
            }
            // Debug.Log(allArrows.First(objName => objName.name.Contains(objNameSelect)));

            if (allArrows.First(objName => objName.name.Contains(objNameSelect)))
            {
                temp = allArrows.First(objName => objName.name.Contains(objNameSelect));
                allArrows.Remove(allArrows.First(objName => objName.name.Contains(objNameSelect)));

                Destroy(temp);
            }
        }
    }
