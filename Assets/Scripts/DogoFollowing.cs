using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogoFollowing : MonoBehaviour
{
    public Vector3 target;
    public float stoppingDistance;
    public float moveSpeed;
    public float approximation;
    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    	float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    	transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    void FixedUpdate() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(transform.position, target) > stoppingDistance + approximation)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, target) < stoppingDistance - approximation)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, -moveSpeed * Time.deltaTime);
        }
    }
}
