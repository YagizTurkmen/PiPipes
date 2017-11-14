using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


void OnTriggerEnter (Collider x) {



	//if (isEntered == false) {

	Debug.Log ("Clone Enter");

	//	isEntered = true;

	//			Debug.Log (other.bounds);

	//	} 


}

void OnTriggerExit (Collider x) {

	//if (isEntered == true) {

		Debug.Log ("Clone Exit");

	//isEntered = false;
	//} 

}



}
