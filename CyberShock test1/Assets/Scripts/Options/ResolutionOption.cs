using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
    public class ResolutionOption : Option
    {
        
        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            GenerateResolutionSubOptions();
            if (currentSubOption.name == "" && subOptionList.Count > 0)
            {
                currentSubOptionIndex = 0;
                currentSubOption = subOptionList[currentSubOptionIndex];
                
            }

            UpdateSuboptionText();
        }        public override void Apply()
        {
            GraphicSettingHelperMethods.ChangeResolution((int)currentSubOption.vector2Value.x, (int)currentSubOption.vector2Value.y);
        }
        private void GenerateResolutionSubOptions()
        {
            //Clear/Empty the list
            subOptionList.Clear();

            //Cycle through each resolution in Screen.resolutions and create a new suboption with the corresponding names, values and the index
            //Then add that suboption to the suboption list
            int i = 0;
            foreach(Resolution r in Screen.resolutions)
            {
                SubOption t = new SubOption();
                t.name = r.width.ToString() + "x" + r.height.ToString();
                t.vector2Value = new Vector2(r.width, r.height);
                t.indexInList = i;
                subOptionList.Add(t);
                i++;
            }
        }
        public void SetCurrentsuboptionByValue(Vector2 v)
        {
            if(subOptionList.Count > 0)
            {
                foreach(var t in subOptionList)
                {
                    if(t.vector2Value == v)
                    {
                        currentSubOption = t;
                        currentSubOptionIndex = t.indexInList;
                        UpdateSuboptionText();
                        return;
                    }
                }

                //If no item is found then we use the fall back option
                Debug.LogWarning("Suboption with value : " + v + " ,not found in :" + gameObject.name + ",using fallback option instead");
                currentSubOption = fallBackOption;
                currentSubOptionIndex = fallBackOption.indexInList;
            }
            else
            {
                Debug.LogError("No items in suboption list : " + gameObject.name);
            }
        }
    }
}

