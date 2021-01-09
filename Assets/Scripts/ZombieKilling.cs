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
        DeathScreen = GameObject.Find("Canvas");
        double r1 = 1.637316/2;
        double r2 = 1.942079/2;
        // double r = Math.Sqrt(Math.Pow(target.position.x-transform.position.x,2)+Math.Pow(target.position.y-transform.position.y,2));
        if(Vector2.Distance(GetComponent<Transform>().position, target.position)<r1+r2){    
            DeathScreen.transform.GetChild(0).gameObject.SetActive(true);
            //
            //Instantiate(DeathScreen, Vector2.zero, Quaternion.identity);
            PlayerMovement plMv = player.GetComponent<PlayerMovement>();
            ZombieFollowing zombieFollowing = GetComponent<ZombieFollowing>();
            zombieFollowing.moveSpeed = 0;
            plMv.velocityAmount = 0;
        }
        
    }
}
