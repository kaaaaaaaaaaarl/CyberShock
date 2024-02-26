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
    // Start is called before the first frame update
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
        /*
        
        _time += Time.deltaTime;
    while (_time >= _interval)
        {
            _time -= _interval;


            Debug.Log("time: "+_time);
            Debug.Log("interval: "+_interval);
        //    foreach (var instance in level)
            for(int k=0; k<=levelLength; k++)
            {
                curStage = level[k];
             //   Debug.Log("level: "+level[k]);

                for (int i = 0; i <= 3; i++)
                {
              //      Debug.Log("Induvidual: "+k+" = "+ Mathf.Floor((level[k] / Mathf.Pow(10, i)) % 10) );

                    switch ( Mathf.Floor((level[k] / Mathf.Pow(10, i)) % 10))
                    {
                        case 1:
                            spriteMask.spawnArrows(i+1);
                            break;
                        
                        default:
                        break;
                    }
                }
                
            }
            Debug.Log("time: "+_time);
            /*
            spriteMask.spawnArrows(1);
            spriteMask.spawnArrows(2);
            spriteMask.spawnArrows(3);
            
         //   _time -= _interval;
         */
        }
        
    
    void ArrowLaunch()
    {
        if(k<=levelLength-2){
            k++;
            curStage = level[k];
            //   Debug.Log("level: "+level[k]);

            for (int i = 0; i <= 2; i++)
            {
            //      Debug.Log("Induvidual: "+k+" = "+ Mathf.Floor((level[k] / Mathf.Pow(10, i)) % 10) );
                switch ( Mathf.Floor((level[k] / Mathf.Pow(10, i)) % 10))
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