using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class spawning : MonoBehaviour
{
    public GameObject rightPrefab;
    public GameObject leftPrefab;
    public GameObject upPrefab;
    public GameObject spacePrefab;
    public GameObject parent;


    public float spawnTime = 1.0f;
    public bool spawnRight = false;
    public bool spawnLeft = false;
    public bool spawnUP = false;
    public bool spawnSpace = false;
    public List<GameObject> allArrows;

    public void spawnArrows(int position)
    {
        switch (position)
        {
            case 1: 
                {
                    GameObject a = Instantiate(rightPrefab) as GameObject;
                    a.transform.SetParent(parent.transform);
                    allArrows.Add(a);
                    a.transform.localPosition  = new Vector3(17f, 0f, 0.02f); 
                    
                  //  Debug.Log(a.transform.position);

                    break;
                }
            case 2: 
                {
                    GameObject a = Instantiate(upPrefab) as GameObject;
                    a.transform.SetParent(parent.transform);
                    allArrows.Add(a);
                    a.transform.localPosition  = new Vector3(0f, 0f, 0.02f);
                    break;
                }
            case 3:
                {
                    GameObject a = Instantiate(leftPrefab) as GameObject;
                    a.transform.SetParent(parent.transform);
                    allArrows.Add(a);
                    a.transform.localPosition  = new Vector3(-17f,0f, 0.02f);
                    break;
                }
            case 4:
                {
                    GameObject a = Instantiate(spacePrefab) as GameObject;
                    a.transform.SetParent(parent.transform);
                    allArrows.Add(a);
                    a.transform.localPosition  = new Vector3(0f, 0f, 0.02f);
                    break;
                }
            default:
                {
                    break;
                }
        }

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
        if (spawnSpace)
        {
            spawnArrows(4);
            spawnSpace = false;
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
                case 3:
                    objNameSelect = "space arrow(Clone)";
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
