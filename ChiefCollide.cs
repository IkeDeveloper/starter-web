using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiefCollide : MonoBehaviour
{

    public AudioSource evillaugh;
    public AudioSource injuredBerry;
    //if you colide with Myan Chief, zap health
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "MayanChief")
        {
            if (!evillaugh.isPlaying)
            {
                evillaugh.Play();
            }
            if (!injuredBerry.isPlaying)
            {
                injuredBerry.Play();
            }

            SceneController.MyHealth = SceneController.MyHealth - 10;
            if (SceneController.MyHealth < 0)
                SceneController.timeout = true;
        }
    }
}