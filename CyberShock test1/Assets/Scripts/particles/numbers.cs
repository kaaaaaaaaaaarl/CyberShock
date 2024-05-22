using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numbers : MonoBehaviour
{
    public GameObject noPointsPrefab;
    public GameObject lowPointsPrefab;
    public GameObject midPointsPrefab;
    public GameObject maxPointsPrefab;
    // Start is called before the first frame update
    public void noPoints()
    {
        Instantiate(noPointsPrefab, this.transform);
    }
    
    public void lowPoints()
    {
        Instantiate(lowPointsPrefab, this.transform);
    }

    public void midPoints()
    {
        Instantiate(midPointsPrefab, this.transform);
    }

    public void highPoints()
    {
        Instantiate(maxPointsPrefab, this.transform);
    }

}
