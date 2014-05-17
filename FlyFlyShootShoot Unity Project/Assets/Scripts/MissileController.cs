using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {
	
	public GameObject explosion;
	public int bounceScale;

	public int gravitationFieldDistance;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 60);
	}
	
	// Update is called once per frame
	void Update () {
		//print ("MISSILE : " + this.gameObject.transform.position);
		if (StaticMethods.Pause) {
			Destroy (this.gameObject);
			explose ();
		} else {
			GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");
			for (int i = 0; i < planets.Length; i++) {
				//print ("PLANET FOUND : " + planets[i].transform.position);
				if (Vector3.Distance(this.transform.position, planets[i].transform.position) < gravitationFieldDistance) {
					Vector3 gravityForce = planets[i].gameObject.rigidbody.mass * (planets[i].transform.position - this.transform.position).normalized;
					this.rigidbody.AddForce(gravityForce);
				}
			}
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag.StartsWith("Enemy")) {
			Destroy(collision.gameObject);
			Destroy (this.gameObject);
			LeapController.Score += 100;

			explose ();
		}
		if (collision.gameObject.tag.Contains("Bouncer")) {
			Destroy(this.gameObject, 20);
			LeapController.Score += 1000;
		}
		if (collision.gameObject.tag.Contains("Asteroid")) {
			Destroy(this.gameObject);
			Destroy(collision.gameObject);
			LeapController.Score += 10;

			explose ();
		}
		if (collision.gameObject.tag.Contains("Planet")) {
			Destroy (this.gameObject);
			
			explose ();
		}
	}

	void explose() {
		GameObject explosionClone = Instantiate(explosion,this.transform.position, this.transform.rotation) as GameObject;
		explosionClone.SetActive(true);
		Destroy (explosionClone, 4);
	}
}