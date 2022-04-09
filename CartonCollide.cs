using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Berry collides with Ribina Carton
public class CartonCollide : MonoBehaviour
{
    public AudioSource gotcarton;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Carton")
        {
            gotcarton.Play();
            SceneController.cartonsCollected = SceneController.cartonsCollected + 1;
            SceneController.MyHealth = SceneController.MyHealth + 5;
            SceneController.score = SceneController.score + 20;

            Destroy(col.gameObject);
        }
         
    }
}