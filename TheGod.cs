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

	static Vector3 deviation = new Vector3 (0.0f, 0.0f, 0.0f);

	static GameObject lastPiece;


	static bok;

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
		if (deviation == new Vector3 (0.0f, 0.0f, 0.0f)) {
			piece.transform.position = mainPart.transform.position + MainPart.hitNormal;
		} else {
			piece.transform.position = lastPiece.transform.position + MainPart.hitNormal;
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
		deviation = deviation + piece.transform.position;

	}





}
