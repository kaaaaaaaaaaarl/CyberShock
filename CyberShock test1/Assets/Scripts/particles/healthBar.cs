using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthBar : MonoBehaviour
{
    public CatchButton CatchButton;
    public GameObject healthBarObject;
    public RectTransform rt;
    [SerializeField] 
        private TMP_Text  _title;
    //  public var healthCount;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       // healthBarObject.ReactTransform.Bottom(110 - CatchButton.health);
        rt.offsetMin = new Vector2 (2,110- CatchButton.health);
        _title.text =  CatchButton.score.ToString();


    }
        
}