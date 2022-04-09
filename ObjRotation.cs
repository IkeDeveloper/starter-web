using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotation : MonoBehaviour
{
    public static float RotSpeed;
    private float x;
    // Start is called before the first frame update
    
    //Disable mouse cursor
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        RotSpeed = 75.0f;
    }

    void Update()
    {
        if (SceneController.activeControls) // only allow movement if game is active
        {
            x -= Input.GetAxis("Mouse X") * RotSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, -x, 0), Time.deltaTime * RotSpeed);

           // Debug.Log(Input.GetAxis("Mouse X"));
        }
    }
}