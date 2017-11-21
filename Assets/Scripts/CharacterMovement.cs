﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody rb;
	[SerializeField] private float moveSpeed = 0.70f;
	[SerializeField] private float rotSpeed = 50.0f;
	[SerializeField] private float jumpHeight = 2.5f;
	private Animator ani;
	private bool isGrounded;

	// MOUSE MOVEMENT
	[SerializeField] GameObject moveToCursor;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
		ani = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {		
		// MOVE ***********************
		if(Input.GetKey(KeyCode.Q)) {
			transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
			//ani.SetBool("isWalking", true);
		}
		if(Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			//ani.SetBool("isWalking", true);
		}
		if(Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
			//ani.SetBool("isWalking", true);
		}
		if(Input.GetKey(KeyCode.E)) {
			transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
			//ani.SetBool("isWalking", true);
		}
		// ROTATE ***********************
		if(Input.GetKey(KeyCode.D)) {
			transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
			//ani.SetBool("isWalking", true);
		}

		if(Input.GetKey(KeyCode.A)) {
			transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
			//ani.SetBool("isWalking", true);
		}
		// JUMP ***********************
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true) {
			rb.AddForce(0f, jumpHeight, 0f, ForceMode.Impulse);
			//ani.SetBool("isWalking", true);
			isGrounded = false;
		}
		// IDLE ***********************
		if(!Input.anyKey) {
			//ani.SetBool("isWalking", false);
		}

		// ---------------------------------------------------------
		// MOUSE MOVEMENT
		// ---------------------------------------------------------
		// TEMP SHUT OFF, WORKS WELL AS A CLICK MOVE.
		/*
		if(Input.GetMouseButtonDown(0)){
			
			// layer mask
			int lMask = LayerMask.GetMask("Ground");
			Debug.Log (lMask);
			Vector3 clickedPos;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 1000f, lMask)){
				
				clickedPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
				Debug.Log(clickedPos);

				Instantiate(moveToCursor, new Vector3(clickedPos.x, moveToCursor.transform.position.y, clickedPos.z), Quaternion.identity);
				//moveToCursor.transform.position = clickedPos;

				// start the movement coroutine
				IEnumerator a = MoveOverSpeed(gameObject, clickedPos, 5.0f);

				// stop previous movement coroutine before starting this one.
				StopAllCoroutines();
				StartCoroutine(a);
			}

		}
		*/


	}

	// MOVE TO COROUTINE
	// Move to the clicked position
	public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed){

		// speed should be 1unit/s
		while(objectToMove.transform.position != end){
			objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}

	}

	// Change isGrounded to true after collision.
	void OnCollisionEnter(Collision collision) {
		isGrounded = true;
	}

}
