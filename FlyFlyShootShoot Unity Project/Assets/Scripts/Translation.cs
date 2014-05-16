using UnityEngine;
using System.Collections;

public class Translation : MonoBehaviour {

    private UDPReceive faceAPI;

    public float multiplyerTranslation = 10;
	public float multiplyerRotation = 1;

	void Start () 
    {
        GameObject contoller = GameObject.FindGameObjectWithTag("GameController");
        faceAPI = contoller.GetComponentInChildren<UDPReceive>();
	}
	
	void Update () 
    {
		// Translate
		//Vector3 newPos = new Vector3(faceAPI.yaw * multiplyerTranslation, 0, 0);
		Vector3 newPos = new Vector3(faceAPI.xPos * multiplyerTranslation, faceAPI.yPos * multiplyerTranslation, (faceAPI.zPos * -multiplyerTranslation));
		this.transform.localPosition = newPos;

		// Rotate
		Quaternion xQuaternion = Quaternion.AngleAxis(faceAPI.yaw * -multiplyerRotation, new Vector3(0, 1, 0));
		transform.localRotation = xQuaternion;
	}
}
