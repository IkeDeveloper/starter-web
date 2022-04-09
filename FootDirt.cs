using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//foot particles when berry is turbocharged
public class FootDirt : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    private bool isPlaying = false;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Clear();    // Reset the particles
    }
    void Update()
    {
        if (!isPlaying)
        {
            if (SceneController.turbotimerstarted)
            {
                particleSystem.Play();
                isPlaying = true;
            }
        }
        isPlaying = false;  
    }
}
