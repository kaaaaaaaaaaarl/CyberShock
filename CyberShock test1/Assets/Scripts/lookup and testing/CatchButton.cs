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
        public GameObject[] enemy = new GameObject[3];
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
        private float[] ratio= new float[3] {2,2,1};
        public float calRatio;
        private float[] ratioTotal = new float[3];

    void Start()
    {
        health = maxHealth;
        enemy = new GameObject[3];

    }

    void checkLocation(int enemyIndex){
       // GameObject temp;
        if (Enter[enemyIndex])
        {
             Debug.Log(enemy[enemyIndex].transform.position.y);
            if ((enemy[enemyIndex].transform.position.y >= 3 && enemy[enemyIndex].transform.position.y <= topColider )||
                (enemy[enemyIndex].transform.position.y >= bottomColider && enemy[enemyIndex].transform.position.y <= 2 )
            )
            {
                score += 100;
                particles.GetComponent<numbers>().lowPoints();
            }
            else if (enemy[enemyIndex].transform.position.y > 2 && enemy[enemyIndex].transform.position.y < 3)
            {
                score += 300;
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
            Enter[enemyIndex]=false;
        }
        
        spawning.DestroyLast(enemyIndex);
        //enemy.Remove(null);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "right arrow(Clone)":
                enemy[0] = collision.gameObject;
                Enter[0] = true;
                collision.transform.localScale = new Vector2(0.25f,0.25f);
                break;

            case "left arrow(Clone)":
                enemy[1] = collision.gameObject;
                Enter[1] = true;
                collision.transform.localScale = new Vector2(0.25f,0.25f);
                break;

            case "up arrow(Clone)":
                enemy[2] = collision.gameObject;
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
        if (Input.GetButtonDown("Horizontal_right") && Input.GetAxis("Horizontal_right") > 0)
        {
            checkLocation(0);
        }

        if (Input.GetButtonDown("Horizontal_left") && Input.GetAxis("Horizontal_left") > 0)
        {
            checkLocation(1);
        }
        
        if (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            checkLocation(2);
            Debug.Log("up button");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
      //  health -= 10;
        switch (collision.gameObject.name)
        {
            case "right arrow(Clone)":
            //    spawning.DestroyLast(0);
                
                // enemy.Remove(collision.gameObject);
                Enter[0] = false;
                collision.transform.localScale = new Vector2(0.2f, 0.2f);
                //collision.size = new Vector3(40, 40, 40);
                break;
            case "left arrow(Clone)":
             //   spawning.DestroyLast(1);

             //   enemy.Remove(collision.gameObject);
                Enter[1] = false;
                collision.transform.localScale = new Vector2(0.2f, 0.2f);
                //collision.size = new Vector3(40, 40, 40);
                break;
            case "up arrow(Clone)":
            //    spawning.DestroyLast(2);

             //   enemy.Remove(collision.gameObject);
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
