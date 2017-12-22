using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {
	//Change in inspector to adjust move speed
	[SerializeField] float moveSpeed = 4f; 

	// Keeps track of our relative forward and right vectors
	Vector3 forward, right; 

	void Start(){

		// Set forward to equal the camera's forward vector
		forward = Camera.main.transform.forward; 

		// make sure y is 0
		forward.y = 0; 

		// make sure the length of vector is set to a max of 1.0
		forward = Vector3.Normalize(forward); 

		// set the right-facing vector to be facing right relative to the camera's forward vector
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

	}

	void Update(){

		// only execute if a key is being pressed
		if(Input.anyKey) {

			Move();

		}

	} 

	void Move(){

		// setup a direction Vector based on keyboard input. GetAxis returns a value between -1.0 and 1.0. 
		// If the A key is pressed, GetAxis(HorizontalKey) will return -1.0. If D is pressed, it will return 1.0
		Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));

		// Our right movement is based on the right vector, movement speed, and our GetAxis command. 
		// We multiply by Time.deltaTime to make the movement smooth.
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");

		// Up movement uses the forward vector, movement speed, and the vertical axis 
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

		// This creates our new direction. By combining our right and forward movements and normalizing them, 
		// we create a new vector that points in the appropriate direction with a length no greater than 1.0
		Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

		// Sets forward direction of our game object to whatever direction we're moving in
		transform.forward = heading;

		// move our transform's position right/left
		transform.position += rightMovement;

		// Move our transform's position up/down
		transform.position += upMovement;

	}
}