using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public Camera FPSCamera;
    public Camera OverHeadCam;
    public AudioSource camerswitch;

    bool fpsCamera = true;

    // Start is called before the first frame update
    void Start()
    {
        FPSCamera.enabled = fpsCamera;
        OverHeadCam.enabled = !fpsCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneController.activeControls) // only allow camera toggle if gane is active
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                if (!camerswitch.isPlaying)
                {
                    camerswitch.Play();
                }
                fpsCamera = !fpsCamera;
                FPSCamera.enabled = fpsCamera;
                OverHeadCam.enabled = !fpsCamera;
            }
        }
    }
}
