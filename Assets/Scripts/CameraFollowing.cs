// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    // Welcome to the github zone  ssssssss
    // new branch
    // Changes to pull
    // Being branch
    void Update()
    {
        transform.position = player.position + offset;
    }
}
