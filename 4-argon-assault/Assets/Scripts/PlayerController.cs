using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float shipSpeed = 15f;
    [Tooltip("How far the player can move left/right")][SerializeField] float maxXMovement = 6f;
    [Tooltip("How far the player can move up/down")] [SerializeField] float maxYMovement = 3f;

    [Header("Screen-position Rotation")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Controller-throw Rotation")]
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float controlYawFactor = 30f;
    [SerializeField] float controlRollFactor = -30f;

    bool controllsEnabled = true;

    float xThrow, yThrow;

    // Update is called once per frame
    void Update ()
    {
        if (controllsEnabled == true)
        {
            HandleTranslation();
            HandleRotation();
        }
    }

    private void OnPlayerDeath () //called by a string method 😠
    {
        controllsEnabled = false; 
    }

    private void HandleRotation ()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow =  yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = xThrow * controlYawFactor;
        float yaw = yawDueToPosition + yawDueToControlThrow;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); //this is a static function that returns a quaternion for what we want to rotate to
    }

    private void HandleTranslation ()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");    // get x throw value from the controller input
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = xThrow * Time.deltaTime * shipSpeed;                  // determine the amount to move the player this 
        float yOffset = yThrow * Time.deltaTime * shipSpeed;
        float rawXPos = transform.localPosition.x + xOffset;               // determine exact position in local space the player will be based on the movements this frame
        float rawYPos = transform.localPosition.y + yOffset;
        float newXPos = Mathf.Clamp(rawXPos, -maxXMovement, maxXMovement); // clamp the x position to the predefined max values so player stays onscreen
        float newYPos = Mathf.Clamp(rawYPos, -maxYMovement, maxYMovement);

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, newYPos, transform.localPosition.z);
    }
}
