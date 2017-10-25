using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour {

	static bool masterIsClicked = false;

	static bool slaveIsClicked = false;

	static string myName;


	GameObject CloneCube;

	// Use this for initialization
	void Start () {
		myName = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {

		if (masterIsClicked == true) {

			masterIsClicked = false;

			if (slaveIsClicked == true) {

				CrateCube ();

			}

		}
		
	}

	static public void SetClick (bool clicked) {

		masterIsClicked = clicked; 

	}

	void CrateCube () {

		CloneCube = (GameObject)Instantiate (gameObject);
		CloneCube.transform.position = new Vector3 (-10.0f, -10.0f,-10.0f);
		//Buraya kooordinatlar gelecek(üste)
	}

	void OnMouseDown () {

		if (slaveIsClicked == true) {
			
			//slaveIsClicked = false;
			FaceDetector.whoIsClicked (incomingSlaveName: gameObject.name);
			//sanal görüntü silinecek
		} else {
			
			//slaveIsClicked = true;
			FaceDetector.whoIsClicked (incomingSlaveName: gameObject.name);
			//sanal görüntü oluşturacak (Masterisclicked == true olduğunda)
		}

	
	}


	static public void amIChoosen (bool youAreChoosen, string yourName){

		if (myName.Equals(yourName)) {

			slaveIsClicked = youAreChoosen;

		}
			
	}



}
