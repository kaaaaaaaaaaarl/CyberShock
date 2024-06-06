using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
    [RequireComponent(typeof(GraphicSettingSaveManager))]
    public class GraphicMenuManager : MonoBehaviour
    {
        //Reference to the options in the scene
        public ResolutionOption resolutionOption;
        public ScreenmodeOption screenmodeOption;
        public QualityLevelOption qualityLevelOption;
        public GameObject closeMenu;

        [Tooltip("The button on keyboard which when pressed will apply the graphic settings")]
        public KeyCode keyboardApplySettingsKey = KeyCode.Return;

        private GraphicSettingDataContainer dataToSave = new GraphicSettingDataContainer();//Data to be saved will be stored in this 
        private GraphicSettingDataContainer dataToLoad = new GraphicSettingDataContainer();//Data will be loaded into this 

        private GraphicSettingSaveManager graphicSettingSaveManager;

        
        private void Start()
        {

            graphicSettingSaveManager = GetComponent<GraphicSettingSaveManager>();

            if(graphicSettingSaveManager.FileExists())
            {
                Load();
                UpdateUIFromLoadedData();
                ApplySettings();
            }
            else
            {
                Debug.Log("New Save file Created!");
                Save();
            }
            if(closeMenu){
                closeMenu.SetActive(false);
            }
            
        }

        private void Update()
        {
            if(Input.GetKeyDown(keyboardApplySettingsKey))
            {
                ApplySettings();
            }
        }
        public void OnApplyButtonPress()
        {
            ApplySettings();
        }
        private void ApplySettings()
        {
            
            resolutionOption.Apply();
            screenmodeOption.Apply();
            qualityLevelOption.Apply();


            Save();
        }
        public void Save()
        {
            //Assign values to dataToSave
            dataToSave.screenHeight = (int)resolutionOption.currentSubOption.vector2Value.y;
            dataToSave.screenWidth = (int)resolutionOption.currentSubOption.vector2Value.x;
            dataToSave.screenMode = screenmodeOption.currentSubOption.integerValue;
            dataToSave.qualityLevel = qualityLevelOption.currentSubOption.integerValue;

            graphicSettingSaveManager.SaveSettings(dataToSave);
        }
        public void Load()
        {
            graphicSettingSaveManager.LoadSettings(out dataToLoad);
        }
        private void UpdateUIFromLoadedData()
        {
            //so that the player will see the current settings on the menu
            resolutionOption.SetCurrentsuboptionByValue(new Vector2(dataToLoad.screenWidth, dataToLoad.screenHeight));
            screenmodeOption.SetCurrentsuboptionByValue(dataToLoad.screenMode);
            qualityLevelOption.SetCurrentsuboptionByValue(dataToLoad.qualityLevel);
            
        }
    }
}

