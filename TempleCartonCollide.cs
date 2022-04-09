using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TempleCartonCollide : MonoBehaviour
{
   
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "TempleCarton")
        {
            SceneController.pyramidCartonCollected = true;
            SceneController.score = SceneController.score + 50;
        }

    }
}