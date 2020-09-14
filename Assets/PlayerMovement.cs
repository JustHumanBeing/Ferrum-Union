// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D playerBody;

    public float velocityAmount = 10f;
    Vector2 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        currentVelocity.x = 0;
        currentVelocity.y = 0;
        if (Input.GetKey("d"))
        {
            currentVelocity.x = velocityAmount;
        } else if (Input.GetKey("a"))
        {
            currentVelocity.x = -velocityAmount;
        }
        if (Input.GetKey("w"))
        {
            currentVelocity.y = velocityAmount;
        } else if (Input.GetKey("s"))
        {
            currentVelocity.y = -velocityAmount;
        }
        playerBody.velocity = currentVelocity;
    }
}
