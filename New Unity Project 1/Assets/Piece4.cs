using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece4 : MonoBehaviour
{

	int Piecenumber = 4;


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



}
