using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {


    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 20f; //4 meters/second
    [Tooltip("In m")]    [SerializeField] float xRange = 5f; //4 meters/second

    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 20f; //4 meters/second
    [Tooltip("In m")] [SerializeField] float yRange = 3.5f; //4 meters/second

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = 5f;

    float xThrow, yThrow;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        //multiplied by time.delta time to keep framerate independent.

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXPosition, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPosition,
            transform.localPosition.y,
            transform.localPosition.z);

        float rawYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(rawYPosition, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x,
            clampedYPosition,
            transform.localPosition.z);
    }
}
