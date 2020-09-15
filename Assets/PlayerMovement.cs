// using System.Collections;
// using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D playerBody;

    public float velocityAmount = 10f;
    Vector2 suggestedVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        suggestedVelocity.x = 0;
        suggestedVelocity.y = 0;
        if (Input.GetKey("d"))
        {
            suggestedVelocity.x = velocityAmount;
        } else if (Input.GetKey("a"))
        {
            suggestedVelocity.x = -velocityAmount;
        }
        if (Input.GetKey("w"))
        {
            suggestedVelocity.y = velocityAmount;
        } else if (Input.GetKey("s"))
        {
            suggestedVelocity.y = -velocityAmount;
        }
        if (suggestedVelocity.x != 0 && suggestedVelocity.y != 0)
        {
            suggestedVelocity.x /= 2;
            suggestedVelocity.y /= 2;
        }
        playerBody.velocity = suggestedVelocity;
        //Movement - End
    }
}
