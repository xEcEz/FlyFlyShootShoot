
var rotVel = 0;

function Update () 
{
	rotVel += 2;
	//var xQuaternion:Quaternion = Quaternion.AngleAxis (rotVel, Vector3.left);
	transform.rotation * Vector3.forward;

}