using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AkshayDhotre.GraphicSettingsMenu
{
    public abstract class Option : MonoBehaviour
    {
        
        [Tooltip("UI Text field for where the suboption name will be displayed")]
        public Text subOptionText;

        [Tooltip("Suboption list, for storing the suboptions")]
        public List<SubOption> subOptionList = new List<SubOption>();

        public SubOption currentSubOption = null;
        [HideInInspector] public int currentSubOptionIndex;

        [Tooltip("If there is any error in loading data, this option will be loaded as the default")]
        public SubOption fallBackOption = new SubOption();

        private void Awake()
        {
            if(fallBackOption.name == "")
            {
                Debug.LogWarning("Fallback option is invalid or not created");
            }
        }
        public abstract void Apply();
        public void UpdateSuboptionText()
        {
            if(currentSubOption != null)
            {
                subOptionText.text = currentSubOption.name;
            }
            else
            {
                Debug.LogError("Current suboption is null in : " + gameObject.name);
            }
        }
        public void SelectNextSubOption()
        {
            currentSubOptionIndex = GetNextSuboptionIndex();
            currentSubOption = subOptionList[currentSubOptionIndex];
            UpdateSuboptionText();
        }
        public void SelectPreviousSubOption()
        {
            currentSubOptionIndex = GetPreviousSubOptionIndex();
            currentSubOption = subOptionList[currentSubOptionIndex];
            UpdateSuboptionText();
        }        private int GetNextSuboptionIndex()
        {
            return GetNextValue(currentSubOptionIndex, subOptionList.Count);
        }
        private int GetPreviousSubOptionIndex()
        {
            return GetPreviousValue(currentSubOptionIndex, subOptionList.Count);
        }
        private int GetNextValue(int currentVal, int maxVal)
        {
            if (currentVal >= maxVal - 1)
            {
                return 0;
            }
            else
            {
                return currentVal + 1;
            }
        }        private int GetPreviousValue(int currentVal, int maxVal)
        {
            if (currentVal == 0)
                return maxVal - 1;

            return currentVal - 1;
        }
    }
}

