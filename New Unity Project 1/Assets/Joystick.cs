using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {

	public float rotSpeed = 20;
	GameObject mainPart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDrag()
	{

		mainPart = GameObject.Find ("GamePlatform");
		float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y")*rotSpeed*Mathf.Deg2Rad;



		//transform.RotateAround(Vector3.up, rotX);
		//transform.RotateAround(Vector3.right, -rotY);
		mainPart.transform.RotateAround(Vector3.up, rotX);
		mainPart.transform.RotateAround(Vector3.right, -rotY);
	}


}
