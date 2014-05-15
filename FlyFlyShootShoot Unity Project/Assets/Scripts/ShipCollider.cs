using UnityEngine;
using System.Collections;

public class ShipCollider : MonoBehaviour {

	public CharacterController parent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		print ("COLLISION DETECTED BETWEEN : " + this.gameObject.name + " AND " + collision.gameObject.name);
		collision.rigidbody.AddForce (parent.velocity * 100);
	}
}
