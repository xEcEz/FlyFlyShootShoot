using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour {

	public float rotationX;
	public float rotationY;
	public float rotationZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rotationY*Time.deltaTime, rotationY*Time.deltaTime,rotationZ*Time.deltaTime); //rotates 50 degrees per second around z axis
	}
}
