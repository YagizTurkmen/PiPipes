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
	static GameObject lastPiece;


	static Vector3 endPointPos;
	static Transform lookAtPos;


	static int cloneCount = 1;
	static bool isThereAClone = false;

	static bool otherOut = true;


	/*static int[][] objectDetails = {
	
		{0,1,2},
		{0,1,2}

	};*/

	static float[,] objectDetails = new float[,] {
		
		{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f },
		{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, 
		{ 0.0f, 0.5f, -0.5f, 0.0f, 1.75f, 0.75f, 90f, 0f, 180f },
		{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, 
		{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }

	};

	static bool[] isSymmetric = {
	
		true,
		true,
		false,
		true,
		true
	
	};


	// Use this for initialization
	void Start ()
	{

		mainPart = GameObject.Find ("MainPart"); 

		endPoint = mainPart;

		lookAtPoint = GameObject.Find ("MainPartChild");

		lastPiece = mainPart; //Bu child olması gerekebilir
		
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

				if ( !isSymmetric [pieceNumber] )
				enterChanger ();

			}

		}



	}

	static void CreatePiece ()
	{

		otherOut = true;

		piece = GameObject.Find ("Piece" + pieceNumber); 
		piece = (GameObject)Instantiate (piece);

		//piece.transform.eulerAngles = new Vector3( mainPart.transform.eulerAngles.x, mainPart.transform.eulerAngles.y , mainPart.transform.eulerAngles.z );

		//piece.transform.rotation = mainPart.transform.rotation;
		//piece.transform.rotation.eulerAngles.y = mainPart.transform.rotation.eulerAngles.y;
		//piece.transform.rotation.eulerAngles.z = mainPart.transform.rotation.eulerAngles.z;


		endPointPos = endPoint.transform.position; // Bir önceki parçadan gelen endpoint'in pozisyonunu alır, sıradaki parçanın koyulacağı yeri belirlemede kullanılır
		Debug.Log ("endPointPos = " +endPointPos);

		lookAtPos = lookAtPoint.transform; // Bir önceki parçadan gelen lookatpoint'in pozisyounu alır, sıradaki parçanın bakacağı yönü belirlemede kullanılır
		Debug.Log ("lookAtPos = " +lookAtPos);

		piece.transform.position = endPointPos;  // Parçayı bir önceki parçanın end pos'una koyar
		//Debug.Log ("endPointPos = " +endPointPos);

		piece.transform.LookAt (lookAtPos);  // Parçayı bir önceki parçanın LookAtPointine çevirir
		//Debug.Log ("endPointPos = " +endPointPos);
		//piece.transform.eulerAngles.x = 0;
		//piece.transform.eulerAngles = new Vector3( piece.transform.eulerAngles.x, piece.transform.eulerAngles.y , 0 );
		//piece.transform.rotation.z = Quaternion.Euler( 0);
		piece.transform.rotation = Quaternion.Euler(piece.transform.eulerAngles.x,piece.transform.eulerAngles.y, mainPart.transform.eulerAngles.y);
		Debug.Log ("piece.transform.euler = " +piece.transform.eulerAngles);
		//piece.transform.Rotate (new Vector3(0,0, -1*piece.transform.eulerAngles.x));
		Debug.Log ("piece.transform.rotation = " +piece.transform.rotation);


		purePiece = piece.transform.GetChild (0).gameObject;   // Parçanın kendisini tanımlar (saf parça), parçanın girişini belirlemede kullanılır
		endPoint = purePiece.transform.GetChild (0).gameObject;   //  Parçanın endpointini tanımlar, endpoint diğer parçanın oturacağı yeri belirler
		lookAtPoint = purePiece.transform.GetChild (2).gameObject;  //  Parçanın lookatpointini tanımlar, lookatpoint diğer parçanın bakacağı yer/yöndür


		integrateToMainPart ();
		isThereAClone = true;



	}

	/*static void positionsFunc () {

		endPointPos = endPoint.transform.position; // Bir önceki parçadan gelen endpoint'in pozisyonunu alır, sıradaki parçanın koyulacağı yeri belirlemede kullanılır
		lookAtPos = lookAtPoint.transform; // Bir önceki parçadan gelen lookatpoint'in pozisyounu alır, sıradaki parçanın bakacağı yönü belirlemede kullanılır
		piece.transform.position = endPointPos;  // Parçayı bir önceki parçanın end pos'una koyar
		piece.transform.LookAt (lookAtPos);  // Parçayı bir önceki parçanın LookAtPointine çevirir

	}*/

	static void integrateToMainPart ()
	{

		piece.transform.parent = mainPart.transform;
		//Destroy (piece.GetComponent<MouseRotation>()); 
		piece.name = "Piece" + pieceNumber + "Clone" + cloneCount;
		purePiece.name = "Piece" + pieceNumber + "ChildClone" + cloneCount;


	}

	static void ChangePiece ()
	{
		Destroy (piece);

		purePiece = lastPiece.transform.GetChild (0).gameObject;   
		endPoint = purePiece.transform.GetChild (0).gameObject;   
		lookAtPoint = purePiece.transform.GetChild (2).gameObject;

		CreatePiece ();
	}

	public static void MakePermenant ()
	{
		if (pieceNumber != 0) {
			cloneCount++;
			isThereAClone = false;
			lastPiece = piece;
			//endPoint = piece;
			//lookAtPoint = piece.transform.GetChild (0).transform.GetChild (2).gameObject; 
			// başlangıçta mainpart yüklü(sarı nokta olan) sonra bunun için nokta yüklemek yerine childları yüklüyoruz HATA
		}
	}

	public static void enterChanger ()
	{


		Vector3 forward = purePiece.transform.forward;
		Vector3 up = purePiece.transform.up;
		Vector3 right = purePiece.transform.right;

		if (otherOut == true) {


			 
			purePiece.transform.position += forward * objectDetails[pieceNumber,0];
			purePiece.transform.position += right * objectDetails[pieceNumber,1];
			purePiece.transform.position += up * objectDetails[pieceNumber,2];

			endPoint.transform.position += forward * objectDetails[pieceNumber,3];
			endPoint.transform.position += right * objectDetails[pieceNumber,4];
			endPoint.transform.position += up * objectDetails[pieceNumber,5];

			purePiece.transform.Rotate (Vector3.forward * objectDetails[pieceNumber,6]);
			purePiece.transform.Rotate (Vector3.right * objectDetails[pieceNumber,7]);
			purePiece.transform.Rotate (Vector3.up * objectDetails[pieceNumber,8]);

			lookAtPoint = purePiece.transform.GetChild (1).gameObject;

			otherOut = false;

		} else {

			purePiece.transform.position -= forward * objectDetails[pieceNumber,0];
			purePiece.transform.position -= right * objectDetails[pieceNumber,1];
			purePiece.transform.position -= up * objectDetails[pieceNumber,2];

			endPoint.transform.position -= forward * objectDetails[pieceNumber,3];
			endPoint.transform.position -= right * objectDetails[pieceNumber,4];
			endPoint.transform.position -= up * objectDetails[pieceNumber,5];

			purePiece.transform.Rotate (Vector3.forward * objectDetails[pieceNumber,6]);
			purePiece.transform.Rotate (Vector3.right * objectDetails[pieceNumber,7]);
			purePiece.transform.Rotate (Vector3.up * objectDetails[pieceNumber,8]);

			lookAtPoint = purePiece.transform.GetChild (2).gameObject;


			otherOut = true;

		}


	}




}
