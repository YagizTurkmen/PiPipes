﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

	bool isEntered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown (){

		//Debug.Log (gameObject.name[5]);
		TheGod.getSlaveClick (incomingSlaveClick: gameObject.name[5]);

	}
	void OnTriggerEnter (Collider other) {



		if (isEntered == false) {

		Debug.Log ("Piece Enter");

		isEntered = true;



		} 


	}

	void OnTriggerExit (Collider other) {

		if (isEntered == true) {

		Debug.Log ("Piece Exit");

		isEntered = false;
		} 

	}

}
