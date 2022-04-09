using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PillCollide : MonoBehaviour
{
    public AudioSource gotpill;
    public AudioSource ascendingtone;
    public AudioSource woohoo;
    public AudioSource giggle;
    public static float boosttime;
    private float rand;
    void OnCollisionEnter(Collision col)
    {
        rand = Random.Range(0.0f, 1.0f);
        if (col.gameObject.tag== "Pills")
        {
            gotpill.Play();
            ascendingtone.Play();
          
            if (rand > 0.5f)
                giggle.Play();
            else
                woohoo.Play();

            if (SceneController.MyHealth < 1)
            {
                if (ascendingtone.isPlaying)
                    ascendingtone.Stop();
            }

             SceneController.turbotimerstarted = true;
            boosttime = SceneController.MyHealth;
            SceneController.score = SceneController.score + 10;
            SceneController.MyHealth=SceneController.MyHealth + 10;
            Destroy(col.gameObject);
        }
    }
}