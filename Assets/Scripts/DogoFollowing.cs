using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DogoMovementState
{
    Dashing,
    Launching,
    Moving
}

public class DogoFollowing : MonoBehaviour
{
    private Vector2 target = Vector2.zero;
    private DogoMovementState moveState = DogoMovementState.Moving;
    private Vector2 difference = Vector2.zero;

    public float stoppingDistance;
    public float moveSpeed;
    public float approximation;
    public float dashForce = 20f;

    private void Start() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        difference = target - (Vector2) transform.position;
    	float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    	transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        if (Input.GetMouseButtonDown(0)) {
            moveState = DogoMovementState.Launching;
        }
    }
    void FixedUpdate() {
        switch (moveState)
        {
            case DogoMovementState.Moving:
                if(Vector2.Distance(transform.position, target) > stoppingDistance + approximation)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
                } else if(Vector2.Distance(transform.position, target) < stoppingDistance - approximation)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target, -moveSpeed * Time.deltaTime);
                }
                break;

            case DogoMovementState.Launching:
                GetComponent<Rigidbody2D>().AddForce(difference.normalized * dashForce, ForceMode2D.Impulse);
                moveState = DogoMovementState.Dashing;
                break;

            case DogoMovementState.Dashing:
                // GetComponent<Rigidbody2D>().AddForce(difference.normalized * dashForce, ForceMode2D.Force);
                // Debug.Log("Adding force");
                // while (!GetComponent<Rigidbody2D>().velocity.Equals(Vector2.zero));
                // while(GetComponent<Rigidbody2D>().velocity.sqrMagnitude > Time.deltaTime) {
                //     GetComponent<Rigidbody2D>() -= Time.deltaTime;
                // }

                moveState = DogoMovementState.Moving;
                break;
        }
            
    }
}
