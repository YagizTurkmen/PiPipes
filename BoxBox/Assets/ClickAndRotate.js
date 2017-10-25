#pragma strict
public var turnTime = 10.0f;

private var enter = false;

function Start () {
	
}

function RotationChanger()
{
var i = 0;

while(enter == false && i <90)

		{
		enter= true;
		yield WaitForSeconds(turnTime/90);
		 transform.Rotate (Vector3.right);
		 i++;
		 enter = false;
		 }

}
/*function PositionChanger()
{
while(denter == false)

		{

		denter= true;
		yield WaitForSeconds(turnTime/DistanceFromCenter);
		  transform.position.y -= DistanceFromCenter/turnTime;
		  transform.position.z += DistanceFromCenter/turnTime;
		 denter = false;

		 }
}
*/

function Update () {


		

		if (Input.GetKeyDown(KeyCode.W))
		{
				 //transform.Rotate (Vector3.right);

		RotationChanger();
		//PositionChanger();
   
		}
    		

			

					
		
		}

		/*if (Input.GetKeyDown(KeyCode.S))
		{
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
		}
		*/
		/* (Input.GetAxis("Mouse X") > 0)
		{
			transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
				0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
		}

		else if (Input.GetAxis("Mouse X") < 0)
		{
			transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
				0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
		}*/
	











