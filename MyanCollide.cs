using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//has berry collided with Mayan Berry
public class MyanCollide : MonoBehaviour
{
    public AudioSource injuredberry;

    void Update()
    {

        //if collided with Myan berry, decrease health
        if (SceneController.AlmostEqual(SceneController.EnemyTransform.position, SceneController.PlayerTransform.position, 1.0f))
        {
            if (!injuredberry.isPlaying)
            {
                injuredberry.Play();
            }

            SceneController.MyHealth = SceneController.MyHealth - (2 * Time.deltaTime);
            //check iff myan zapping health
            if (SceneController.MyHealth < 1)
            {
                SceneController.timeout = true;
                injuredberry.Stop();
            }
        }

    }
 }



    


