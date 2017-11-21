using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour {
	
	public float thrustPower = 10f;
	public GameObject projectile;
	public GameObject spawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(Input.GetMouseButtonDown(0)) {
			GameObject clone;
			clone = Instantiate(projectile, spawn.transform.position, projectile.transform.rotation) as GameObject;
			clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * thrustPower);
		}

	}
}
