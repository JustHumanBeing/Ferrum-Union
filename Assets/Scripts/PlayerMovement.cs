// using System.Collections;
// using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D playerBody;
    public GameObject DeathScreen;

    public float velocityAmount = 10f;
    Vector2 suggestedVelocity;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    	float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    	transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    void FixedUpdate() {
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
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            isAlive = false;
            DeathScreen.transform.GetChild(0).gameObject.SetActive(true);
            //
            //Instantiate(DeathScreen, Vector2.zero, Quaternion.identity);
            velocityAmount = 0;
        }
    }
}
