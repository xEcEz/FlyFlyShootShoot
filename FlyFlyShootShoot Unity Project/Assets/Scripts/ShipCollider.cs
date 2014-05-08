using UnityEngine;
using System.Collections;

public class ShipCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		print ("COLLISION DETECTED BETWEEN : " + this.gameObject.name + " AND " + collision.gameObject.name);
	}
}
