﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiSi_Mover : MonoBehaviour
{
 
     public float speed;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = -transform.right * speed;
    }
}

