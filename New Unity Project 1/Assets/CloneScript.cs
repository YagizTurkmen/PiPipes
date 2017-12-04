using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour {

	bool isEntered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter (Collider other) {



		if (isEntered == false) {

		Debug.Log ("Clone Enter");

		isEntered = true;

					Debug.Log (other.bounds);

		} 


	}

	void OnTriggerExit (Collider other) {

		if (isEntered == true) {

		Debug.Log ("Clone Exit");

		isEntered = false;
		} 

	}



}
