using UnityEngine;
using System.Collections;

public class Yaw : MonoBehaviour {
    private UDPReceive faceAPI;

    public float multiplyer = 1;

    void Start()
    {
        GameObject contoller = GameObject.FindGameObjectWithTag("GameController");
        faceAPI = contoller.GetComponentInChildren<UDPReceive>();
    }
	
	void Update () 
    {
        //this.transform.eulerAngles = new Vector3(0, -faceAPI.yaw, 0);
        Quaternion xQuaternion = Quaternion.AngleAxis(faceAPI.yaw * -multiplyer, new Vector3(0, 1, 0));
        transform.localRotation = xQuaternion;
	}
}
