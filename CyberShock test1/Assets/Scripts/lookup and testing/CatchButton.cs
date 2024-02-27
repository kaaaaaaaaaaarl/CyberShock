using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CatchButton : MonoBehaviour
{
  //  numbers noPoints;
    [Header("Values")]
        public int score =0;
        public int maxHealth;
        public int health;
        bool[] Enter = new bool[] { false, false, false };
    [Header("Other")]
        public List<GameObject> enemy = new List<GameObject>();
        [SerializeField]
        spawning spawning;
    [Header("Prefabs")]
        public GameObject rightPrefab;
        public GameObject leftPrefab;
        public GameObject upPrefab;
        public GameObject colider;
        public GameObject particles;

        private int score1Point, score2Point, score3Point;
        private float topColider=4.2f, bottomColider = 0.2f;
    void Start()
    {
        health = maxHealth;
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

            case "left arrow(Clone)":
                enemy.Add(collision.gameObject);
                Enter[1] = true;
                collision.transform.localScale = new Vector2(0.25f,0.25f);
                break;

            case "up arrow(Clone)":
                enemy.Add(collision.gameObject);
                Enter[2] = true;
                collision.transform.localScale = new Vector2(0.25f,0.25f);
                break;

            default:
                break;
        }
    }

    void Update()
    {
        //button pressed to the right
        if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0)
        {
            if (Enter[0])
            {
                if ((enemy[0].transform.position.y >= 3 && enemy[0].transform.position.y <= 4 )||
                    (enemy[0].transform.position.y >= 1 && enemy[0].transform.position.y <= 2 )
                )
                {
                    score += 1;
                    particles.GetComponent<numbers>().lowPoints();
                    
                }
                else if (enemy[0].transform.position.y > 2 && enemy[0].transform.position.y < 3)
                {
                    score += 5;
                    particles.GetComponent<numbers>().highPoints();
                }
                else
                {
                    health -= 10;
                    particles.GetComponent<numbers>().noPoints();
                    if (health <= 0)
                    {
                     //   Debug.Log("Lose");
                    }
                }
                Enter[0]=false;
            }
       //     Debug.Log("delete");
            spawning.DestroyLast();
        }
        if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {
            if (Enter[1])
            {
                //Debug.Log(enemy[0].transform.position.y);
            
                if ((enemy[0].transform.position.y >= 3 && enemy[0].transform.position.y <= 4 )||
                    (enemy[0].transform.position.y >= 1 && enemy[0].transform.position.y <= 2 )
                )
                {
                    score += 1;
                    particles.GetComponent<numbers>().lowPoints();
                }
                else if (enemy[0].transform.position.y > 2 && enemy[0].transform.position.y < 3)
                {
                    score += 5;
                    particles.GetComponent<numbers>().highPoints();
                }
                else
                {
                    health -= 10;
                    if (health <= 0)
                    {
                     //   Debug.Log("Lose");
                    }
                }
                Enter[1]=false;
            }
       //     Debug.Log("delete");
            spawning.DestroyLast();
        }
        if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") < 0)
        {

            if (Enter[2])
            {
                
                //Debug.Log(enemy[0].transform.position.y);
            
                if ((enemy[0].transform.position.y >= 3 && enemy[0].transform.position.y <= 4 )||
                    (enemy[0].transform.position.y >= 1 && enemy[0].transform.position.y <= 2 )
                )
                {
                    score += 1;
                    particles.GetComponent<numbers>().lowPoints();
                }
                else if (enemy[0].transform.position.y > 2 && enemy[0].transform.position.y < 3)
                {
                    score += 5;
                    particles.GetComponent<numbers>().highPoints();
                }
                else
                {
                    health -= 10;
                    particles.GetComponent<numbers>().noPoints();
                    if (health <= 0)
                    {
                        Debug.Log("Lose");
                    }
                }
                Enter[0]=false;
            }
            Debug.Log("delete");
            spawning.DestroyLast();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        health -= 10;
        switch (collision.gameObject.name)
        {
            case "right arrow(Clone)":
                enemy.Remove(collision.gameObject);
                Enter[0] = false;
                collision.transform.localScale = new Vector2(0.2f, 0.2f);
                //collision.size = new Vector3(40, 40, 40);
                break;
            case "left arrow(Clone)":
                enemy.Remove(collision.gameObject);
                Enter[1] = false;
                collision.transform.localScale = new Vector2(0.2f, 0.2f);
                //collision.size = new Vector3(40, 40, 40);
                break;
            case "up arrow(Clone)":
                enemy.Remove(collision.gameObject);
                Enter[2] = false;
                collision.transform.localScale = new Vector2(0.2f, 0.2f);
                //collision.size = new Vector3(40, 40, 40);
                break;

            default:
                
          //      Debug.Log("exited collision: " + collision.gameObject.name);
                break;
        }
    }

}
