﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCarton : MonoBehaviour
{
    
     public float speed = 45f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime*speed);
    }
    
}
