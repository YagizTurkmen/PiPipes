using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGod : MonoBehaviour {

	static int masterClickCounter = 0;

	static int slaveClickCounter = 0; //LastHit

	static int oldSlaveClick = 0;

	static int oldMasterClick = 0;

	static GameObject piece;

	static int cloneCount = 1;

	static bool isThereAClone = false;

	static GameObject lastPiece;

	static string[] objectDetails = { 
		"0",	//cop
		"f1", //piece1
		"r0", //piece2
		"u0"
	
	};


	 

	//static MouseRotation mouseRotation;





	static Vector3 newCoor; 

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static public void getMasterClick (int incomingMasterClick) {

		oldMasterClick = masterClickCounter;
		oldSlaveClick = slaveClickCounter;
		masterClickCounter = incomingMasterClick;
		clickControl (isMaster: true);

	}

	static public void getSlaveClick (int incomingSlaveClick) {

		oldSlaveClick = slaveClickCounter;
		oldMasterClick = masterClickCounter;
		slaveClickCounter = incomingSlaveClick;
		clickControl (isMaster: false);

	}
		
	static void clickControl (bool isMaster) {

		//Debug.Log ("girdi");

		if (slaveClickCounter != 0 && masterClickCounter != 0) {

			if (oldMasterClick == 0 || oldSlaveClick == 0) {

				//CREATE
				CreatePiece ();
				Debug.Log("Master : "+ masterClickCounter + "  Slave : "+ slaveClickCounter + "  Yaratıldı");

			} else {

				if (isMaster == true && oldMasterClick != masterClickCounter) {

					//changeposition
					ChangePosPiece ();
					//piece.transform.position = new Vector3 (-10f, -10f, masterClickCounter);
					Debug.Log("Master : "+ oldMasterClick + " ile Master : "+ masterClickCounter + "  Taşındı");


				} else {

					if (oldSlaveClick != slaveClickCounter) {

						//DEĞİŞTİRME
						Debug.Log("Slave : "+ oldSlaveClick + " ile Slave : "+ slaveClickCounter + "  Değişti");
						ChangePosPiece ();
					}

				}

			}

		}

	}

	static void CreatePiece () {

		piece = GameObject.Find ("Piece" + slaveClickCounter);
		piece = (GameObject)Instantiate (piece);
		integrateToMainPart ();



	}

	static void integrateToMainPart() {

		GameObject mainPart = GameObject.Find ("MainPart");
		if (isThereAClone == false) {
			piece.transform.position = mainPart.transform.position + MainPart.hitNormal;
		} else {

			Vector3 forward = lastPiece.transform.forward;
			Vector3 up = lastPiece.transform.up;
			Vector3 right = lastPiece.transform.right;

		

			switch (objectDetails[slaveClickCounter])
			{
			case "f0":
				piece.transform.position = lastPiece.transform.position - forward;
				break;
			case "f1":
				piece.transform.position = lastPiece.transform.position + forward;
				break;
			case "u0":
				piece.transform.position = lastPiece.transform.position - up;
				break;
			case "u1":
				piece.transform.position = lastPiece.transform.position + up;
				break;
			case "r0":
				piece.transform.position = lastPiece.transform.position - right;
				break;
			case "r1":
				piece.transform.position = lastPiece.transform.position + right;
				break;
			default:
				Debug.Log("Error in integrateToMainPart");
				break;
			}
				



		}
		piece.transform.rotation = mainPart.transform.rotation;
		piece.transform.parent = mainPart.transform;
		//MouseRotation mouserotation;
		//mouserotation = piece.GetComponent<MouseRotation>();
		Destroy (piece.GetComponent<MouseRotation>()); 
		//Destroy (piece.GetComponent<"Piece"+slaveClickCounter>());
		piece.name = "Piece" + slaveClickCounter + "Clone" + cloneCount;
		//Destroy (piece);
		//mouseRotation = GetComponent<MouseRotation>();
		//Destroy(mouseRotation);




	}

	static void ChangePosPiece()

	{
		Destroy (piece);
		CreatePiece ();
	}

	public static void MakePermenant()
	{
		cloneCount++;

		//masterClickCounter = 0;
		slaveClickCounter = 0;
		oldSlaveClick = 0;
		//oldMasterClick = 0;
		lastPiece = piece;
		isThereAClone = true;
	}






}
