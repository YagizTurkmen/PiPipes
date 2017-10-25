#pragma strict

function Start () {
	
}

function Update () {
	
}

     
 
  
 function FixedUpdate() {
 
 //Camera Right Spin from CameraFpos
     if (Input.GetButton("Right"))
     {
     
         Camera.main.transform.position.x = 65.757;
         Camera.main.transform.position.z = 22.58412;
         Camera.main.transform.rotation = Quaternion.Euler(0,270,0);
     }
     
 //Camera Right Spin from CameraRpos
    else if (Input.GetButton("Right"))
     {
     
         Camera.main.transform.position.x = 18.0817;
         Camera.main.transform.position.z = 69.14645;
         Camera.main.transform.rotation = Quaternion.Euler(0,180,0);
     }
     
 //Camera Right Spin from CameraBpos
     else if (Input.GetButton("Right"))
     {
     
         Camera.main.transform.position.x = -32.8335;
         Camera.main.transform.position.z = 22.04136;
         Camera.main.transform.rotation = Quaternion.Euler(0,90,0);
     }
     
 //Camera Right Spin from CameraLpos
    else if (Input.GetButton("Right"))
     {
     
         Camera.main.transform.position.x = 18.9608;
         Camera.main.transform.position.z = -25.7975;
         Camera.main.transform.rotation = Quaternion.Euler(0,0,0);
     }
 }
