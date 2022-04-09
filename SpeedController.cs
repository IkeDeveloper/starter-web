using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    Animator anim;
    public float velocity;
    public float zPos;
   
    public AudioSource berryfootsteps;
  

    Rigidbody rb;
    public static float speed;

    
    
    void Start()
    {
        velocity = 0.0f;
        speed = 5.5f; //berry speed
        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate() //movment physics
    {
        if (SceneController.activeControls)
        {
            Vector3 moveBy = transform.forward * zPos;
            rb.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);
        }
    }
    void Update()
    {
            zPos = Input.GetAxisRaw("Vertical");

            if (zPos != 0)
            {
                if (!berryfootsteps.isPlaying)
                {
                    berryfootsteps.Play();
                }
                velocity = Mathf.Clamp(velocity, -9.5f, 10.5f);
                velocity += zPos / 2;
            }
            else
            {
                velocity = 0;
            }
            anim.SetFloat("velocity", velocity);

            
            bool IsWavePressed = Input.GetKey(KeyCode.Q) && (velocity == 0);
            anim.SetBool("IsWave", IsWavePressed);     
    }
}
