using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonreader : MonoBehaviour
{
    public spawning spriteMask;
    public float curStage;
    float _interval = 0f;
    int k = 0;
    float levelLength; 
    int[] level;
    public float speed;
    public TextAsset textJSON;
    [System.Serializable]


    public class Player
    {
        public int BPM;
        public int[] arrows;
    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] BeatMap;
    }
    public PlayerList myPLayerList = new PlayerList();

    //Needs to calculate how fast it will need to do
    public float GetSpeed()
    {
        
        return speed;
    }
    void Start()
    {
        myPLayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
        _interval = 60f / myPLayerList.BeatMap[0].BPM;
        
        levelLength = myPLayerList.BeatMap[0].arrows.Length;
        level = myPLayerList.BeatMap[0].arrows;

        InvokeRepeating("ArrowLaunch", 2.0f, _interval);

      //  Debug.Log(levelLength);
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    
    void ArrowLaunch()
    {
        if(k<=levelLength-2){
            k++;
            curStage = level[k];
            //   Debug.Log("level: "+level[k]);

            for (int i = 0; i <= 3; i++)
            {
            //      Debug.Log("Induvidual: "+k+" = "+ Mathf.Floor((level[k] / Mathf.Pow(10, i)) % 10) );
                switch (Mathf.Floor((level[k] / Mathf.Pow(10, i)) % 10))
                {
                    case 1:
                        spriteMask.spawnArrows(i+1);
                        break;
                    default:
                    break;
                }
            }
        }
    }
}