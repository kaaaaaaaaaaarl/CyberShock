using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace AkshayDhotre.GraphicSettingsMenu
{

    public class KeyboardMouseInput : MonoBehaviour
    {
        [Tooltip("Object which shows that the current object is selected, it can be a simple pointer next to the option" +
            "or an image overlay over the option")]
        public GameObject optionMarker;

        private bool selected = false;
        private Option myOption;

        private EventSystem currentEventSystem;

        private void Awake()
        {
            myOption = GetComponent<Option>();
            currentEventSystem = EventSystem.current;
        }

        private void Update()
        {
            if(IsMenuActive())
            {
                KeyboardControls();
            }
        }

        private void KeyboardControls()
        {
            if (selected)
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    myOption.SelectNextSubOption();
                }
                else if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    myOption.SelectPreviousSubOption();
                }
            }
        }
        private bool IsMenuActive()
        {
            if (transform.root.GetComponent<Canvas>().enabled)
            {
                return true;
            }

            return false;
        }

        public void SetMarkerActive(bool val)
        {
            optionMarker.SetActive(val);
            selected = val;
            if (val == true && currentEventSystem.currentSelectedGameObject != this.gameObject)
            {
                currentEventSystem.SetSelectedGameObject(null);
                currentEventSystem.SetSelectedGameObject(this.gameObject);
            }
        }
    }
}

