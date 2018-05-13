using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    
    [Tooltip("In ms^-1")][SerializeField] float shipSpeed = 15f;
    [Tooltip("How far the player can move left/right")][SerializeField] float maxXMovement = 6f;
    [Tooltip("How far the player can move up/down")] [SerializeField] float maxYMovement = 3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleXMovement();
        HandleYMovement();
    }

    private void HandleYMovement()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");      // same as HandleXMovement function except for y axis
        float yOffset = yThrow * Time.deltaTime * shipSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawYPos, -maxYMovement, maxYMovement);

        transform.localPosition = new Vector3(transform.localPosition.x, newYPos, transform.localPosition.z);
    }

    private void HandleXMovement()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");    // get x throw value from the controller input
        float xOffset = xThrow * Time.deltaTime * shipSpeed;                  // determine the amount to move the player this 
        float rawXPos = transform.localPosition.x + xOffset;               // determine exact position in local space the player will be based on the movements this fram
        float newXPos = Mathf.Clamp(rawXPos, -maxXMovement, maxXMovement); // clamp the x position to the predefined max values so player stays onscreen

        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
