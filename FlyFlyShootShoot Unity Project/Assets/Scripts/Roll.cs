using UnityEngine;
using System.Collections;

public class Roll : MonoBehaviour {

    private UDPReceive faceAPI;

    public float multiplyer = 1;

    void Start()
    {
        GameObject contoller = GameObject.FindGameObjectWithTag("GameController");
        faceAPI = contoller.GetComponentInChildren<UDPReceive>();
    }

    void Update()
    {
        //this.transform.eulerAngles = new Vector3(0, 0, faceAPI.roll);
        Quaternion xQuaternion = Quaternion.AngleAxis(faceAPI.roll * multiplyer, new Vector3(0, 0, 1));
        transform.localRotation = xQuaternion;
    }
}
