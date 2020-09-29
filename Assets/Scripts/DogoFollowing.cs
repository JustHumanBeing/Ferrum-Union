using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogoFollowing : MonoBehaviour
{
    public Transform target;
    public float stoppingDistance;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = target.position - transform.position;
    	float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    	transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    void FixedUpdate() {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
