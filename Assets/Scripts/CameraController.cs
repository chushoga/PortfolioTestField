using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	private string dir;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.W)) {
			dir = "UP";
			Debug.Log(dir + " <==");
		} else if(Input.GetKeyDown(KeyCode.S)) {
			dir = "DOWN";
		} else if(Input.GetKeyDown(KeyCode.A)) {
			dir = "LEFT";
		} else if(Input.GetKeyDown(KeyCode.D)) {
			dir = "RIGHT";
		} else if(Input.GetKeyUp(KeyCode.W)|Input.GetKeyUp(KeyCode.S)|Input.GetKeyUp(KeyCode.A)|Input.GetKeyUp(KeyCode.D)) {
			dir = "";
		}

		// Camera Scroll
		if(dir == "UP") {
			transform.Translate(0, 0, 20 * Time.deltaTime);
		} else if(dir == "DOWN") {
			transform.Translate(0, 0, -20 * Time.deltaTime);
		} else if(dir == "LEFT") {
			transform.Translate(-20 * Time.deltaTime, 0, 0);
		} else if(dir == "RIGHT"){
			transform.Translate(20 * Time.deltaTime, 0, 0);
		}
	}
}
