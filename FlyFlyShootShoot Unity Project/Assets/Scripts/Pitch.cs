using UnityEngine;
using System.Collections;

public class Pitch : MonoBehaviour {
    
    private UDPReceive faceAPI;

    public float multiplyer = 1;

    void Start()
    {
        GameObject contoller = GameObject.FindGameObjectWithTag("GameController");
        faceAPI = contoller.GetComponentInChildren<UDPReceive>();
    }

    void Update()
    {
        //this.transform.eulerAngles = new Vector3(-faceAPI.pitch, 0, 0);
        Quaternion xQuaternion = Quaternion.AngleAxis(faceAPI.pitch * -multiplyer, new Vector3(1, 0, 0));
        transform.localRotation = xQuaternion;
    }
}
