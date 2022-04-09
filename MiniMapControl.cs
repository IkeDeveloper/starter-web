using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//toggles minmap vsability
public class MiniMapControl : MonoBehaviour
{
    public GameObject panel;
    
    void Start()
    {
        panel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneController.activeControls) // only toggle minimap if game is active
        { 
            if (Input.GetKeyDown(KeyCode.M))
                 panel.SetActive(!panel.activeSelf);
        }
    }
}
