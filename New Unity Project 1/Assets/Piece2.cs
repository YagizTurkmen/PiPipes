using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece2 : MonoBehaviour
{

	int Piecenumber = 2;

	bool isEntered = false;

	// Use this for initialization
	void Start ()
	{



	}

	// Update is called once per frame
	void Update ()
	{



	}

	void OnMouseDown ()
	{

		if (gameObject.name == "Piece" + Piecenumber + "Child") {
			TheGod.getSlaveClick (incomingSlaveClick: Piecenumber);
		}
			
	}

	void OnTriggerEnter (Collider other) {



		if (isEntered == false) {

			Debug.Log ("Enter");

			isEntered = true;

//			Debug.Log (other.bounds);

		} 


	}
		
	void OnTriggerExit (Collider other) {

		if (isEntered == true) {

			Debug.Log ("Exit");

			isEntered = false;
		} 

	}





}
