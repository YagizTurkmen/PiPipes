using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetector : MonoBehaviour {

	Vector3 objForward;
	Vector3 objUp;
	Vector3 objRight;

	static string currentSlaveName = "";


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {

		//Bunlar yüzey belirleyici
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		objForward = gameObject.transform.forward;
		objUp = gameObject.transform.up;
		objRight = gameObject.transform.right;
		Physics.Raycast(ray, out hit);
		GetHitFace(hit);
		//Bunlar yüzey belirleyici


		CubeCreator.SetClick(clicked: true);
	
	}

	public enum MCFace
	{
		Error,
		Up,
		Down,
		East,
		West,
		North,
		South
	}

	public MCFace GetHitFace(RaycastHit hit)
	{
		if (hit.normal == objForward*(-1)) {
			//Debug.Log ("MCFace.South");
			return MCFace.South;
		}

		if (hit.normal == objForward) {
			//Debug.Log ("MCFace.North");
			return MCFace.North;
		}

		if (hit.normal == objRight) {
			//Debug.Log ("MCFace.East");
			return MCFace.East;
		}

		if (hit.normal == objRight*(-1)) {
			//Debug.Log ("MCFace.West");
			return MCFace.West;
		}

		if (hit.normal == objUp) {
			//Debug.Log ("MCFace.Up");
			return MCFace.Up;
		}

		if (hit.normal == objUp*(-1)) {
			//Debug.Log ("MCFace.Down");
			return MCFace.Down;
		}

		return MCFace.Error;
	}

	static public void whoIsClicked (string incomingSlaveName){ //kimin görüntüsünün çıkacağı kontrolü burada sağlanıyor

		if (currentSlaveName.Equals ("") != true) {

			if (currentSlaveName.Equals (incomingSlaveName)) {

				CubeCreator.amIChoosen (youAreChoosen: false,yourName: incomingSlaveName); //iki kere aynı objeye tıklanırsa HEPSİNE you are not choosen

			} else {

				CubeCreator.amIChoosen (youAreChoosen: true,yourName: incomingSlaveName); //bir objeye tıklandıktan sonra başka bir objeye tıklandığında ikinci tıklanan objeye sen choosen
				CubeCreator.amIChoosen (youAreChoosen: false,yourName: currentSlaveName); //bir objeye tıklandıktan sonra başka bir objeye tıklandığında ilk tıklanan objeye sen choosen değil
			}

		} else {

			CubeCreator.amIChoosen (youAreChoosen: true,yourName: incomingSlaveName); //hiçbir objeye tıklanmadığında sen choosen

		}

		currentSlaveName = incomingSlaveName; 


	}



}
