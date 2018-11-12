using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {


    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f; //4 meters/second
    [Tooltip("In m")]    [SerializeField] float xRange = 5f; //4 meters/second

    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f; //4 meters/second
    [Tooltip("In m")] [SerializeField] float yRange = 5f; //4 meters/second


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        //multiplied by time.delta time to keep framerate independent.

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXPosition, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPosition,
            this.transform.localPosition.y,
            this.transform.localPosition.z);

        float rawYPosition = transform.localPosition.y + yOffset;
        // // 

    }
}
