using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamJump : MonoBehaviour
{
    
    private float jumpForce;
    public float distancetoground = 0.1f;
    bool IsjumpPressed;
    bool IsClicked;
    public AudioSource jumpAudio;

    Rigidbody rb;
    Animator anim2;
 
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim2 = gameObject.GetComponent<Animator>();
        jumpForce = 5.0f;
    }

    
    
    void Update()
    {
        if (SceneController.activeControls)
      
        {
            IsClicked = (Input.GetMouseButtonUp(0));
            IsjumpPressed = (Input.GetKeyDown(KeyCode.Space) || (IsClicked));

            if ((IsjumpPressed) && IsOnGround())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                //jump if spacebar or left mouse button is pressed


                jumpAudio.Play(); //play jump sound


                anim2.SetBool("IsRunJump", true);
            }
            else
            {
                anim2.SetBool("IsRunJump", false);

            }

        }  
    }
    //checks if berry is grounded
   
    bool IsOnGround()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distancetoground))
            return true;
        else
            return false;
    }
  
}

