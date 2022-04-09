using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Plays sound of the wind through the trees
public class TreeWindSound : MonoBehaviour
{ 
    public AudioSource treeWind;
  
    void Update()
    {
        if (!treeWind.isPlaying)
            treeWind.Play();
    }
}
