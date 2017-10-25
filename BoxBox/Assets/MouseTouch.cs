using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTouch : MonoBehaviour {
	bool Selected = false;
	GameObject CloneCube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



		
	}

	void OnMouseDown () {

		if (Selected == false) {
			gameObject.GetComponent<Renderer> ().material.color = new Color(0.5f, 0.6f, 1.0f, 1.0f);
			CloneCube = (GameObject)Instantiate (gameObject);
			CloneCube.transform.position = new Vector3 (-10.0f, -10.0f,-10.0f);
			CloneCube.GetComponent<Renderer> ().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

			Selected = true;

		
		} else if (Selected == true) {
			gameObject.GetComponent<Renderer> ().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			Destroy (CloneCube);
			Selected = false;
		}
	}
}
// this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);