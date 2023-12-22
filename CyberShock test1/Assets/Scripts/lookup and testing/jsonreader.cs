using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonreader : MonoBehaviour
{
    public spawning spriteMask;
    float _time = 1f;
    float _interval = 3f;
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
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        while (_time >= _interval)
        {
            spriteMask.spawnArrows(1);
            _time -= _interval;
        }
    }
}
