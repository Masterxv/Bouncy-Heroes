using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public Rigidbody2D rb;
    // how much it multiplers the gravity when the charater is falling down
    public float fallMultipler = 2.5f;

   
   


    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        if (rb.velocity.y > 0 || rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipler - 1) * Time.deltaTime;
            Debug.Log("add gravity");
        }

    }


}
