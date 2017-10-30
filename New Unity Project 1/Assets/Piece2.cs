using System.Collections.Generic;
using UnityEngine;

public class Piece2 : MonoBehaviour {

	int Piecenumber = 2;

	bool leftOut = true;

		
	// Use this for initialization
	void Start () {



	}

	// Update is called once per frame
	void Update () {



	}

	void OnMouseDown () {

		Vector3 forward = transform.forward;
		Vector3 up = transform.up;
		Vector3 right = transform.right;

		if (gameObject.name == "Piece" + Piecenumber) {
			TheGod.getSlaveClick (incomingSlaveClick: Piecenumber);
		}

		/*if (leftOut == true) {




			transform.position += right * 0.5f;
			transform.position += up * -0.5f;

			transform.Rotate (Vector3.forward * 90f);
			transform.Rotate (Vector3.up * 180f);



			leftOut = false;

		} else {

			transform.position += right * -0.5f;
			transform.position += up * 0.5f;

			transform.Rotate (Vector3.forward * 90f);
			transform.Rotate (Vector3.up * -180f);




			leftOut = true;

		}*/

		

	}



}
