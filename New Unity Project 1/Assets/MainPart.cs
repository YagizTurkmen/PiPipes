using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPart : MonoBehaviour {
	int Piecenumber = 0;

	bool isEntered = false;

	// Use this for initialization
	void Start () {

		//Debug.Log( gameObject.GetComponent(typeof(ScriptableObject)));
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {



		if (isEntered == false) {

		Debug.Log ("MainPart Enter");

		isEntered = true;

					Debug.Log (other.bounds);

		} 


	}

	void OnTriggerExit (Collider other) {

		if (isEntered == true) {

		Debug.Log ("MainPart Exit");

		isEntered = false;
		} 

	}



	/*void OnMouseDown () {

		//Bunlar yüzey belirleyici
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		objForward = gameObject.transform.forward;
		objUp = gameObject.transform.up;
		objRight = gameObject.transform.right;
		Physics.Raycast(ray, out hit);
		GetHitFace(hit);
		//Bunlar yüzey belirleyici

	}*/




		
	/*public void GetHitFace(RaycastHit hit) {

		hitNormal = hit.normal;
		Debug.Log (hitNormal);

		if (hit.normal == objForward*(-1)) {
			//Debug.Log ("MCFace.South");
			//return MCFace.South;
			TheGod.getMasterClick (incomingMasterClick: 5);
		}

		if (hit.normal == objForward) {
			//Debug.Log ("MCFace.North");
			//return MCFace.North;
			TheGod.getMasterClick (incomingMasterClick: 2);
		}

		if (hit.normal == objRight) {
			//Debug.Log ("MCFace.East");
			//return MCFace.East;
			TheGod.getMasterClick (incomingMasterClick: 4);
		}

		if (hit.normal == objRight*(-1)) {
			//Debug.Log ("MCFace.West");
			//return MCFace.West;
			TheGod.getMasterClick (incomingMasterClick: 3);
		}

		if (hit.normal == objUp) {
			//Debug.Log ("MCFace.Up");
			//return MCFace.Up;
			TheGod.getMasterClick (incomingMasterClick: 1);
		}

		if (hit.normal == objUp*(-1)) {
			//Debug.Log ("MCFace.Down");
			//return MCFace.Down;
			TheGod.getMasterClick (incomingMasterClick: 6);
		}

		//return MCFace.Error;
	}*/
	

}
