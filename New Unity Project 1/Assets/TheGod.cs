using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGod : MonoBehaviour {

	static int pieceNumber = 0; //LastHit
	static int oldPieceNumber;

	static GameObject piece;
	static GameObject lastPiece;

	static int cloneCount = 1;
	static bool isThereAClone = false;

	static int lastCloneNumber = 0;

	//static int HowmanyDidObjectCreated = 5;

	static string[] objectDetails = { //boruların çıkışları ne tarafa bakıyor
		"r1",		//main
		"f1", 		//piece1
		"r1", 		//piece2
		"u0"		//piece3
	
	};

	//public static string[] objectDetails = new string[HowmanyDidObjectCreated+1] ;
	//public static Vector3[] objectSize = new Vector3[HowmanyDidObjectCreated+1] ;
	//double[] balance = new double[10];





	static Vector3[] objectSize = 
	{
		new Vector3(1.0f,1.0f,1.0f),	//main
		new Vector3(1.0f,1.0f,1.0f), 	//piece1
		new Vector3(2.0f,1.0f,1.0f),  	//piece2
		new Vector3(1.0f,2.0f,1.0f),  	//piece3
		new Vector3(0.0f,0.0f,0.0f) 	//piece4



	};

	static Vector3[] objectDegrees = 
	{
		new Vector3(0.0f,0.0f,0.0f),	//main
		new Vector3(1.0f,1.0f,1.0f), 	//piece1
		//new Vector3(Vector3.right * 90),  	//piece2
		new Vector3(1.0f,2.0f,1.0f),  	//piece3
		new Vector3(0.0f,0.0f,0.0f) 	//piece4



	};





	// Use this for initialization
	void Start () {



		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	static public void getSlaveClick (int incomingSlaveClick) {

		Debug.Log (objectSize[1]);
		Debug.Log (objectSize[2]);
		Debug.Log (objectSize[3]);
		
		oldPieceNumber = pieceNumber;
		pieceNumber = incomingSlaveClick;
		clickControl ();

	}
		
	static void clickControl () {


		if (isThereAClone == false) {

				//CREATE
				CreatePiece ();

			} else {

				/*if (isMaster == true && oldMasterClick != masterClickCounter) {
					//TO DO: task 
					//changeposition
					ChangePosPiece ();
					//piece.transform.position = new Vector3 (-10f, -10f, masterClickCounter);
					Debug.Log("Master : "+ oldMasterClick + " ile Master : "+ masterClickCounter + "  Taşındı");


				} else {*/

					if (oldPieceNumber != pieceNumber) {

						//DEĞİŞTİRME
						ChangePiece ();
					

				}

			}



	}

	static void CreatePiece () {

		isThereAClone = true;
		piece = GameObject.Find ("Piece" + pieceNumber);
		piece = (GameObject)Instantiate (piece);
		integrateToMainPart ();



	}

	static void integrateToMainPart() {

		GameObject mainPart = GameObject.Find ("MainPart");

		if (lastPiece == null)
			lastPiece = mainPart;

			Vector3 forward = lastPiece.transform.forward;
			Vector3 up = lastPiece.transform.up;
			Vector3 right = lastPiece.transform.right;
			
			piece.transform.rotation = lastPiece.transform.rotation;
			piece.transform.Rotate (Vector3.forward * -90);

			
		

			switch (objectDetails[lastCloneNumber])
			{
			case "f0":
				piece.transform.position = lastPiece.transform.position - forward*(objectSize [pieceNumber].z+objectSize [lastCloneNumber].z)/2;
				break;
			case "f1":
				piece.transform.position = lastPiece.transform.position + forward*(objectSize [pieceNumber].z+objectSize [lastCloneNumber].z)/2;
				break;
			case "u0":
				piece.transform.position = lastPiece.transform.position - up*(objectSize [pieceNumber].y+objectSize [lastCloneNumber].y)/2;
				break;
			case "u1":
				piece.transform.position = lastPiece.transform.position + up*(objectSize [pieceNumber].y+objectSize [lastCloneNumber].y)/2;
				break;
			case "r0":
				piece.transform.position = lastPiece.transform.position - right*(objectSize [pieceNumber].x+objectSize [lastCloneNumber].x)/2;
				break;
			case "r1":
				piece.transform.position = lastPiece.transform.position + right*(objectSize [pieceNumber].x+objectSize [lastCloneNumber].x)/2;
				break;
			default:
				Debug.Log("Error in integrateToMainPart");
				break;

		}


		piece.transform.parent = mainPart.transform;
		Destroy (piece.GetComponent<MouseRotation>()); 
		piece.name = "Piece" + pieceNumber + "Clone" + cloneCount;



	}

	static void ChangePiece()

	{
		Destroy (piece);
		CreatePiece ();
	}

	public static void MakePermenant()
	{
		if(pieceNumber != 0){	
		cloneCount++;
		lastCloneNumber = pieceNumber;
		lastPiece = piece;
		isThereAClone = false;
	}
	}

	/*public static Vector3 TranslationInCoor ()
	{



	}*/






}
