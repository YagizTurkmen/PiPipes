using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGod : MonoBehaviour
{

	static int pieceNumber = 0;
	//LastHit
	static int oldPieceNumber;

	static GameObject piece;
	static GameObject purePiece;
	static GameObject endPoint;
	static GameObject lookAtPoint;
	static GameObject mainPart;

	static Vector3 endPointPos;
	static Transform lookAtPos;

	static int cloneCount = 1;
	static bool isThereAClone = false;

	static bool otherOut = true;



	// Use this for initialization
	void Start ()
	{

		mainPart = GameObject.Find ("MainPart"); 

		endPoint = mainPart;

		lookAtPoint = GameObject.Find ("MainPartChild");

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	static public void getSlaveClick (int incomingSlaveClick)
	{

		oldPieceNumber = pieceNumber;
		pieceNumber = incomingSlaveClick;
		clickControl ();

	}

	static void clickControl ()
	{


		if (isThereAClone == false) {

			//CREATE
			CreatePiece ();

		} else {

			if (oldPieceNumber != pieceNumber) {

				//DEĞİŞTİRME
				ChangePiece ();
					

			} else {

				enterChanger ();

			}

		}



	}

	static void CreatePiece ()
	{

		otherOut = true;

		isThereAClone = true;
		piece = GameObject.Find ("Piece" + pieceNumber); 
		piece = (GameObject)Instantiate (piece);
		integrateToMainPart ();



	}

	static void integrateToMainPart ()
	{

		endPointPos = endPoint.transform.position; // Bir önceki parçadan gelen endpoint'in pozisyonunu alır, sıradaki parçanın koyulacağı yeri belirlemede kullanılır
		lookAtPos = lookAtPoint.transform; // Bir önceki parçadan gelen lookatpoint'in pozisyounu alır, sıradaki parçanın bakacağı yönü belirlemede kullanılır

		purePiece = piece.transform.GetChild (0).gameObject;   // Parçanın kendisini tanımlar (saf parça), parçanın girişini belirlemede kullanılır
		endPoint = purePiece.transform.GetChild (0).gameObject;   //  Parçanın endpointini tanımlar, endpoint diğer parçanın oturacağı yeri belirler
		lookAtPoint = purePiece.transform.GetChild (1).gameObject;  //  Parçanın lookatpointini tanımlar, lookatpoint diğer parçanın bakacağı yer/yöndür



		piece.transform.position = endPointPos;  // Parçayı bir önceki parçanın end pos'una koyar
		piece.transform.LookAt (lookAtPos);  // Parçayı bir önceki parçanın LookAtPointine çevirir

	
		piece.transform.parent = mainPart.transform;
		//Destroy (piece.GetComponent<MouseRotation>()); 
		piece.name = "Piece" + pieceNumber + "Clone" + cloneCount;
		purePiece.name = "Piece" + pieceNumber + "ChildClone" + cloneCount;


	}

	static void ChangePiece ()
	{
		Destroy (piece);
		CreatePiece ();
	}

	public static void MakePermenant ()
	{
		if (pieceNumber != 0) {
			cloneCount++;
			isThereAClone = false;
		}
	}

	public static void enterChanger ()
	{


		Vector3 forward = purePiece.transform.forward;
		Vector3 up = purePiece.transform.up;
		Vector3 right = purePiece.transform.right;

		if (otherOut == true) {


			 

			purePiece.transform.position += right * 0.5f;
			purePiece.transform.position += up * -0.5f;

			endPoint.transform.position += right * 1.75f;
			endPoint.transform.position += up * 0.75f;

			purePiece.transform.Rotate (Vector3.forward * 90f);
			purePiece.transform.Rotate (Vector3.up * 180f);



			otherOut = false;

		} else {

			purePiece.transform.position += right * -0.5f;
			purePiece.transform.position += up * 0.5f;

			endPoint.transform.position += right * -1.75f;
			endPoint.transform.position += up * -0.75f;

			purePiece.transform.Rotate (Vector3.forward * 90f);
			purePiece.transform.Rotate (Vector3.up * -180f);




			otherOut = true;

		}


	}






}
