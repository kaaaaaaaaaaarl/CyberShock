using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject pressButtonArea;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(ExampleCoroutine());
        }
    }
    public void EnteredTrigger()
    {
        float size = this.gameObject.GetComponent<Renderer>().bounds.size.y;

        Vector3 rescale = this.gameObject.transform.localScale;

        rescale.y = 1.0f * rescale.y / size;

        this.gameObject.transform.localScale = rescale;
        // this.transform.localSize = new Vector2(this.GameObject.localScale.x + 1f, this.GameObject.localScale.y + 1f);
    }
    IEnumerator ExampleCoroutine()
    {

        this.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        Debug.Log("space key was pressed");
        yield return new WaitForSeconds(0.2f);
        this.transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
    }


}
