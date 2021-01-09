using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DogoFollowing : MonoBehaviour
{
    private Vector2 target = Vector2.zero;
    private Vector2 difference = Vector2.zero;

    public GameObject score;
    public float stoppingDistance;
    public float moveSpeed;
    public float approximation;

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
    }
    void FixedUpdate() {
            if(Vector2.Distance(transform.position, target) > stoppingDistance + approximation)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            } else if(Vector2.Distance(transform.position, target) < stoppingDistance - approximation)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, -moveSpeed * Time.deltaTime);
            }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Enemy" && GameObject.Find("Player").GetComponent<PlayerMovement>().isAlive) {
            Destroy(other.gameObject);
            score = GameObject.Find("Counter");
            score.GetComponent<ScoreSystem>().IncreaseScore();
        }
    }
}
