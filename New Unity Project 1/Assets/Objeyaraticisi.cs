using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeyaraticisi : MonoBehaviour {


	static GameObject SObjesi;
	bool updatestopper = true;
	float y = 0.5f;  //daire icindeki kare
	float z = 2.0f;	//degisken
	float z_ust;
	float z_alt;
	float x = 0.025f; //dilimlerin genişliği


	float xcenter = 0.975f; 
	float ycenter = 0.31f;
	float zcenter;

	// Use this for initialization
	void Start () {

		SObjesi = gameObject.transform.GetChild (0).gameObject;


	}
	
	// Update is called once per frame
	void Update () {

		if(updatestopper)
		{

			while(xcenter > 0.25f) 
			{
			z_ust = Mathf.Sqrt (1.25f*1.25f - (xcenter -1.0f - x/2) * (xcenter -1.0f - x/2))+1;
			z_ust = -1 * z_ust;
			z_alt = Mathf.Sqrt (0.75f*0.75f - (xcenter -1.0f + x/2) * (xcenter -1.0f + x/2))+1;
			z_alt = -1 * z_alt;
			z = (float) (z_ust - z_alt);
			zcenter = (float)(z_ust + z_alt) / 2;
			//Debug.Log ("z_ust = " +z_ust);
			//Debug.Log ("z_alt = " +z_alt);
			//Debug.Log ("zcenter = " +zcenter);
			BoxCollider bc = SObjesi.AddComponent<BoxCollider> () as BoxCollider;
			bc.center = new Vector3(xcenter,ycenter,zcenter);
			bc.size = new Vector3(x,y,z);
			xcenter = xcenter - x;
			}


		while(xcenter > -0.2499f)
			{
			z_ust = Mathf.Sqrt (1.25f*1.25f - (xcenter -1.0f - x/2) * (xcenter -1.0f - x/2))+1;
			z_ust = -1 * z_ust;
			z_alt = -1;
			z = (float) (z_ust - z_alt);
			zcenter = (float)(z_ust + z_alt) / 2;
			//Debug.Log ("z_ust = " +z_ust);
			//Debug.Log ("z_alt = " +z_alt);
			//Debug.Log ("zcenter = " +zcenter);
			BoxCollider bc = SObjesi.AddComponent<BoxCollider> () as BoxCollider;
			bc.center = new Vector3(xcenter,ycenter,zcenter);
			bc.size = new Vector3(x,y,z);
			xcenter = xcenter - x;
			}
			//------------------------


			xcenter = 0.25f - x;

			while(xcenter > -0.2499f)
			{
				z_ust = Mathf.Sqrt (1.25f*1.25f - (xcenter +1.0f + x/2) * (xcenter +1.0f + x/2))-1;
				z_ust =  z_ust;
				z_alt = -1;
				z = (float) (z_ust - z_alt);
				zcenter = (float)(z_ust + z_alt) / 2;
				//Debug.Log ("z_ust = " +z_ust);
				//Debug.Log ("z_alt = " +z_alt);
				//Debug.Log ("zcenter = " +zcenter);
				BoxCollider bc = SObjesi.AddComponent<BoxCollider> () as BoxCollider;
				bc.center = new Vector3(xcenter,ycenter,zcenter);
				bc.size = new Vector3(x,y,z);
				xcenter = xcenter - x;
			}


			while(xcenter > -0.99f) 
			{
				z_ust = Mathf.Sqrt (1.25f*1.25f - (xcenter +1.0f + x/2) * (xcenter +1.0f + x/2))-1;
				z_ust = z_ust;
				z_alt = Mathf.Sqrt (0.75f*0.75f - (xcenter +1.0f - x/2) * (xcenter +1.0f - x/2))-1;
				z_alt = z_alt;
				z = (float) (z_ust - z_alt);
				zcenter = (float)(z_ust + z_alt) / 2;
				//Debug.Log ("z_ust = " +z_ust);
				//Debug.Log ("z_alt = " +z_alt);
				//Debug.Log ("zcenter = " +zcenter);
				BoxCollider bc = SObjesi.AddComponent<BoxCollider> () as BoxCollider;
				bc.center = new Vector3(xcenter,ycenter,zcenter);
				bc.size = new Vector3(x,y,z);
				xcenter = xcenter - x;
			}


			updatestopper = false;
		}
		}
		
	}

