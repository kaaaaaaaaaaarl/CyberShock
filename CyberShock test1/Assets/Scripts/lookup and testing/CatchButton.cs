using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchButton : MonoBehaviour
{
    public int score;
    public GameObject rightPrefab, leftPrefab, upPrefab, colider;
    public bool[] Enter = new bool[] { false, false, false };
    List<GameObject> enemy = new List<GameObject>();

    private int score1Point, score2Point, score3Point;
    private float topColider=4.2f, bottomColider = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "right arrow(Clone)":
                enemy.Add(collision.gameObject);
                Enter[0] = true;
                collision.transform.localScale = new Vector2(0.25f,0.25f);
                break;
            default:
                
                Debug.Log("entered collision: " + collision.gameObject.name);
                break;
        }
    }
    void Update()
    {
        if (Enter[0])
        {
            Debug.Log(enemy[0].transform.position.y);
            if(Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") >0)
                if(enemy[0].transform.position.y >=3 && enemy[0].transform.position.y <= 4)
                {
                    score += 1;
                }else if (enemy[0].transform.position.y > 2 && enemy[0].transform.position.y < 3)
                {
                    score += 5;
                }else if(enemy[0].transform.position.y >=1 && enemy[0].transform.position.y <= 2)
                {
                    score += 1;
                }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "right arrow(Clone)":
                enemy.Remove(collision.gameObject);
                Enter[0] = false;
                collision.transform.localScale = new Vector2(0.2f, 0.2f);
                //collision.size = new Vector3(40, 40, 40);
                break;

            default:
                
                Debug.Log("exited collision: " + collision.gameObject.name);
                break;

        }
    }

}
