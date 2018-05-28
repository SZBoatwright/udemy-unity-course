using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMovementDirection : MonoBehaviour {

    [Tooltip ("Value between 0-1. 0 being no movement, 1 being instant.")][SerializeField][Range(0,1)] float turnSpeed = 1;

    float xPosLastFrame;
    float yPosLastFrame;
    float zPosLastFrame;
    
	void Start () {
        xPosLastFrame = transform.position.x;
        yPosLastFrame = transform.position.y;
        zPosLastFrame = transform.position.z;
    }
    
    private void LateUpdate() //using LateUpdate will allow you to overwrite other animations 😉
    {
        ControlRotation();
    }

    private void ControlRotation()
    {
        // determine change in position
        float xDelta = transform.position.x - xPosLastFrame;
        float yDelta = transform.position.y - yPosLastFrame;
        float zDelta = transform.position.z - zPosLastFrame;

        Vector3 rotation = new Vector3 (xDelta, yDelta, zDelta);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), turnSpeed);

        //set transform for this frame for use in next frame         
        xPosLastFrame = transform.position.x;
        yPosLastFrame = transform.position.y;
        zPosLastFrame = transform.position.z;
    }
}