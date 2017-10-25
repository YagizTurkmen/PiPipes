#pragma strict

public var SizeOfCubes = 1;
public var DistanceBetweenCubesCenters = 1.2;
 public var ColliderSize = 3.4;



function Start () {
	
}

function Update () {
ColliderSize = 2*DistanceBetweenCubesCenters+SizeOfCubes;
var boxCollider = GetComponent(BoxCollider) as BoxCollider;
boxCollider.size = Vector3(ColliderSize,ColliderSize,ColliderSize);
	
}
