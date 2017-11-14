using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

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
	void OnTriggerEnter (Collider x) {



		//if (isEntered == false) {

			Debug.Log ("Enter");

		//	isEntered = true;

			//			Debug.Log (other.bounds);

	//	} 


	}

	void OnTriggerExit (Collider x) {

		//if (isEntered == true) {

			Debug.Log ("Exit");

			//isEntered = false;
		//} 

	}
}
