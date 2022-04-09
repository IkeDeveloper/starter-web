using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//does berry collide with the fires
public class FireCollide : MonoBehaviour
{
    public AudioSource ouch;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "FireLogs")
        {
            if (!ouch.isPlaying)
            {
                ouch.Play();
            }

            SceneController.MyHealth = SceneController.MyHealth -3.0f;

            if (SceneController.MyHealth < 0)
                SceneController.timeout = true;
        }

    }
}
    

