using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MouseRotation : MonoBehaviour 
{
	public float rotSpeed = 20;
	void Start () {

	}

	// Update is called once per frame
	void Update () {



	}



	void OnMouseDrag()
	{
		float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y")*rotSpeed*Mathf.Deg2Rad;

		transform.RotateAround(Vector3.up, -rotX);
		transform.RotateAround(Vector3.right, rotY);
	}
}