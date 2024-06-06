using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

namespace AkshayDhotre.GraphicSettingsMenu
{
    [System.Serializable]
    [XmlRoot("Settings")]
    public class GraphicSettingDataContainer
    {
        public int screenWidth = 0;
        public int screenHeight = 0;

        public int screenMode = -1;

        public int qualityLevel = -1;

        
       
    }
}

