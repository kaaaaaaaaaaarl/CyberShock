﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObject : MonoBehaviour
{
    public static TextAsset playableMapData;
    public static AudioClip mainSong;
    public static string songName = "Dimensionalized system";
    [System.Serializable]
    public class ScoreData
    {
        public int[] Scores;
    }
}
