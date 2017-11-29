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

	 

	//static GameObject temporary;


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
		{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, 
		{ 0.0f, -1.0f, 0.0f, -2.0f, 1f, 0.0f, 0f, 0f, 90f },
		{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }, 
		{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f },
		{ 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f }

	};

	static bool[] isSymmetric = {
	
		true,
		true,
		true,
		false,
		true,
		true
	
	};

	public static Vector3 pureForward;
	public static Vector3 pureUp; 
	public static Vector3 pureRight;



	// Use this for initialization
	void Start ()
	{

		mainPart = GameObject.Find ("MainPart"); 

		endPoint = mainPart;

		lookAtPoint = GameObject.Find ("MainPartChild");

		lastPiece = mainPart;


		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}





	static public void getSlaveClick (int incomingSlaveClick)
	{
		incomingSlaveClick = incomingSlaveClick - 48;
		//Debug.Log (incomingSlaveClick);
		oldPieceNumber = pieceNumber;
		pieceNumber = incomingSlaveClick;
		clickControl ();

	}

	static void clickControl ()
	{


		if (isThereAClone == false) {

			//CREATE
			CreatePiece ();

			//purePiece.GetComponent<Collider> ().isTrigger = true;


		} else {



			if (oldPieceNumber != pieceNumber) {

				//purePiece.GetComponent<Collider> ().isTrigger = false;

				//DEĞİŞTİRME
				ChangePiece ();

				//purePiece.GetComponent<Collider> ().isTrigger = true;
					

			} else {

				//purePiece.GetComponent<Collider> ().isTrigger = false;

				if ( !isSymmetric [pieceNumber] )
				enterChanger ();

				//purePiece.GetComponent<Collider> ().isTrigger = true;

			}
				

		}



	}

	static void ChangePiece ()
	{
		Destroy (piece);

		purePiece = lastPiece.transform.GetChild (0).gameObject;   
		endPoint = purePiece.transform.GetChild (0).gameObject;   
		lookAtPoint = purePiece.transform.GetChild (2).gameObject;

		CreatePiece ();
	}

	static void CreatePiece ()
	{

		otherOut = true;

		piece = GameObject.Find ("Piece" + pieceNumber); 
	

		piece = (GameObject)Instantiate (piece);

		positionsFunc ();

		purePiece = piece.transform.GetChild (0).gameObject;   // Parçanın kendisini tanımlar (saf parça), parçanın girişini belirlemede kullanılır
		endPoint = purePiece.transform.GetChild (0).gameObject;   //  Parçanın endpointini tanımlar, endpoint diğer parçanın oturacağı yeri belirler
		lookAtPoint = purePiece.transform.GetChild (2).gameObject;  //  Parçanın lookatpointini tanımlar, lookatpoint diğer parçanın bakacağı yer/yöndür


		integrateToMainPart ();
		isThereAClone = true;


		pureForward = purePiece.transform.forward;
		pureUp = purePiece.transform.up;
		pureRight = purePiece.transform.right;



	}

	static void positionsFunc () {


		endPointPos = endPoint.transform.position; // Bir önceki parçadan gelen endpoint'in pozisyonunu alır, sıradaki parçanın koyulacağı yeri belirlemede kullanılır
		lookAtPos = lookAtPoint.transform; // Bir önceki parçadan gelen lookatpoint'in pozisyounu alır, sıradaki parçanın bakacağı yönü belirlemede kullanılır

		piece.transform.position = endPointPos;  // Parçayı bir önceki parçanın end pos'una koyar
		piece.transform.LookAt (lookAtPos);  // Parçayı bir önceki parçanın LookAtPointine çevirir

		transformRounding (piece);

	}

	static void integrateToMainPart ()
	{


		piece.transform.parent = mainPart.transform;
		//Destroy (piece.GetComponent<MouseRotation>()); 
		piece.name = "Piece" + pieceNumber + "Clone" + cloneCount;
		purePiece.name = "Piece" + pieceNumber + "ChildClone" + cloneCount;

		//temporary = GameObject.Find ("Piece" + pieceNumber + "Clone" + cloneCount);


		//Debug.Log (piece.transform.localEulerAngles);

		transformRounding (piece);

		if ( !((piece.transform.localEulerAngles.x > 269.9 && piece.transform.localEulerAngles.x < 270.1) || (piece.transform.localEulerAngles.x > 89.9 && piece.transform.localEulerAngles.x < 90.1) || (piece.transform.localEulerAngles.x > 179.9 && piece.transform.localEulerAngles.x < 180.1) ) )
			piece.transform.localEulerAngles = new Vector3 (0, piece.transform.localEulerAngles.y, 0);


		if ( !((piece.transform.localEulerAngles.y > 269.9 && piece.transform.localEulerAngles.y < 270.1) || (piece.transform.localEulerAngles.y > 89.9 && piece.transform.localEulerAngles.y < 90.1) || (piece.transform.localEulerAngles.y > 179.9 && piece.transform.localEulerAngles.y < 180.1) ) ) 
			piece.transform.localEulerAngles = new Vector3 (piece.transform.localEulerAngles.x, 0, 0);

		piece.transform.localEulerAngles = new Vector3 (piece.transform.localEulerAngles.x, piece.transform.localEulerAngles.y, 0);

		//Debug.Log (piece.transform.localEulerAngles);


	}
		
	public static void MakePermenant ()
	{
		if (pieceNumber != 0  && isThereAClone == true) 
		{


			cloneCount++;
			isThereAClone = false;
			lastPiece = piece;
			Destroy(purePiece.GetComponent<Piece>());
			purePiece.AddComponent<CloneScript>();

			//piece.AddComponent<CloneScript> ();
			//purePiece.GetComponent<Collider> ().isTrigger = false;
		}


	}

	public static void Rotate () 
	{
		if (isThereAClone == true) 
		{

			piece.transform.Rotate (Vector3.forward * 90);

			transformRounding (piece);

		}

	}

	public static void enterChanger ()
	{
		Vector3 forward = purePiece.transform.forward;
		Vector3 right = purePiece.transform.right;
		Vector3 up = purePiece.transform.up;



		if (otherOut == true) {


			 
			purePiece.transform.position += pureForward * objectDetails[pieceNumber,0];
			purePiece.transform.position += pureRight * objectDetails[pieceNumber,1];
			purePiece.transform.position += pureUp * objectDetails[pieceNumber,2];

			endPoint.transform.position += forward * objectDetails[pieceNumber,3];
			endPoint.transform.position += right * objectDetails[pieceNumber,4];
			endPoint.transform.position += up * objectDetails[pieceNumber,5];

			purePiece.transform.Rotate (Vector3.forward * objectDetails[pieceNumber,6]);
			purePiece.transform.Rotate (Vector3.right * objectDetails[pieceNumber,7]);
			purePiece.transform.Rotate (Vector3.up * objectDetails[pieceNumber,8]);

			lookAtPoint = purePiece.transform.GetChild (1).gameObject;

			otherOut = false;

		} else {

			purePiece.transform.position -= pureForward * objectDetails[pieceNumber,0];
			purePiece.transform.position -= pureRight * objectDetails[pieceNumber,1];
			purePiece.transform.position -= pureUp * objectDetails[pieceNumber,2];

			endPoint.transform.position -= forward * objectDetails[pieceNumber,3];
			endPoint.transform.position -= right * objectDetails[pieceNumber,4];
			endPoint.transform.position -= up * objectDetails[pieceNumber,5];

			purePiece.transform.Rotate (-1 * Vector3.forward * objectDetails[pieceNumber,6]);
			purePiece.transform.Rotate (-1 *Vector3.right * objectDetails[pieceNumber,7]);
			purePiece.transform.Rotate (-1 *Vector3.up * objectDetails[pieceNumber,8]);

			lookAtPoint = purePiece.transform.GetChild (2).gameObject;


			otherOut = true;

		}

		transformRounding (purePiece);


	}
		
	static public float NumberRounding (float number) {

		//Debug.Log (number);

		number = number * 1000;

		number = Mathf.Round (number);

		//Debug.Log (number);

		number = number / 1000;



		//Debug.Log (number);

		return number;

	}

	static public void transformRounding (GameObject obj) {

		obj.transform.localEulerAngles = new Vector3 (NumberRounding (obj.transform.localEulerAngles.x), NumberRounding (obj.transform.localEulerAngles.y), NumberRounding (obj.transform.localEulerAngles.z));
		obj.transform.localPosition = new Vector3 (NumberRounding (obj.transform.localPosition.x), NumberRounding (obj.transform.localPosition.y), NumberRounding (obj.transform.localPosition.z));

	}
		

}
