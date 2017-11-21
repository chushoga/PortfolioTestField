using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called osce per frame
	void Update () {
		// ---------------------------------------------------------
		// LOOK TOWARDS MOUSE
		// ---------------------------------------------------------
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		float midPoint = (transform.position - Camera.main.transform.position).magnitude * 0.5f;

		transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint); 
	}
}
