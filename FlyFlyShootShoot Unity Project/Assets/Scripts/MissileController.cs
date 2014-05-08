using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {
	
	public GameObject explosion;
	public int bounceScale;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag.StartsWith("Enemy")) {
			Destroy(collision.gameObject);
			Destroy (this.gameObject);
			LeapController.Score += 100;
		}
		if (collision.gameObject.tag.Contains("Bouncer")) {
			Destroy(this.gameObject, 20);
			LeapController.Score += 1000;
		}
		if (collision.gameObject.tag.Contains("Asteroid")) {
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
			LeapController.Score += 10;
		}
	}
}