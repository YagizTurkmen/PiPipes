﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece3 : MonoBehaviour {

	int Piecenumber = 3;


	// Use this for initialization
	void Start () {
		TheGod.objectSize [Piecenumber] = gameObject.transform.localScale;


	}

	// Update is called once per frame
	void Update () {



	}

	void OnMouseDown () {

		if (gameObject.name == "Piece" + Piecenumber) {
			TheGod.getSlaveClick (incomingSlaveClick: Piecenumber);
		}

	}



}
