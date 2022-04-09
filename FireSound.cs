using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
    public AudioSource firesound;
  
   
    // Update is called once per frame
    void Update()
    {
        if (!firesound.isPlaying)

            firesound.Play();
    }
}
