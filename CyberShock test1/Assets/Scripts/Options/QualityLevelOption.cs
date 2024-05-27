using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
    public class QualityLevelOption : Option
    {

        private void Awake()
        {
            Inititalize();
        }

        private void Inititalize()
        {
            GenerateQualityLevelSuboptions();

            //If currentSuboption is null, assign the first element from the sub option list
            if(currentSubOption.name == "" && subOptionList.Count > 0)
            {
                currentSubOptionIndex = 0;
                currentSubOption = subOptionList[0];
                UpdateSuboptionText();
               
            }
        }        public override void Apply()
        {
            GraphicSettingHelperMethods.ChangeQualitySettings(currentSubOption.integerValue);
        }
        private void GenerateQualityLevelSuboptions()
        {
            //Unity stores the quality level from Edit/ProjectSettings/Quality in QualitySettings.names according to thier integer value
            int i = 0;
            foreach(string qualityLevel in QualitySettings.names)
            {
                SubOption t = new SubOption();
                t.name = qualityLevel;
                t.indexInList = i;
                t.integerValue = i;
                subOptionList.Add(t);
                i++;
            }
        }
        public void SetCurrentsuboptionByValue(int v)
        {
            if (subOptionList.Count > 0)
            {
                foreach (var t in subOptionList)
                {
                    if (t.integerValue == v)
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
        }
    }
}

