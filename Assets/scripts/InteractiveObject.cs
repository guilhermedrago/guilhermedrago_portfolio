using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour

    {
        public GameObject panelToOpen; // Assign the panel you want to open in the Inspector

        void Update()
        {
            // Check for mouse click input
            if (Input.GetMouseButtonDown(0)) // 0 is the mouse left button
            {
                // Create a ray from the camera through the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Perform the raycast
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the raycast hit this object
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        TogglePanel();
                    }
                }
            }
        }

        private void TogglePanel()
        {
            // Check if the panel is assigned
            if (panelToOpen == null)
            {
                Debug.LogError("Panel to open not assigned on " + gameObject.name);
                return;
            }

            // Toggle the panel's active state
            bool isActive = panelToOpen.activeSelf;
            panelToOpen.SetActive(!isActive);

            // Debug output to confirm the action
            if (!isActive)
            {
                Debug.Log("Opened panel from: " + gameObject.name);
            }
            else
            {
                Debug.Log("Closed panel from: " + gameObject.name);
            }
        }



    }
