using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieKilling : MonoBehaviour
{
    public Transform target;
    public GameObject DeathScreen;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double r1 = 1.637316;
        double r2 = 1.019662;
        // double r = Math.Sqrt(Math.Pow(target.position.x-transform.position.x,2)+Math.Pow(target.position.y-transform.position.y,2));
        if(Vector2.Distance(transform.position, target.position)<r1+r2){    
            DeathScreen.SetActive(true);
            PlayerMovement plMv = player.GetComponent<PlayerMovement>();
            GameObject zombie =  GameObject.Find("Zombie");
            DogoFollowing zombieFollowing = zombie.GetComponent<DogoFollowing>();
            zombieFollowing.moveSpeed = 0;
            plMv.velocityAmount = 0;
        }
        
    }
}
