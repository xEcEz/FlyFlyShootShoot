using UnityEngine;
using System.Collections;

public class AsteroidsGenerator : MonoBehaviour {

	public GameObject prefabAsteroid;
	public float force;
	public float popRange;
	public float scale;
	public int asteroidNumber;

	// Use this for initialization
	void Start () {
		int i;
		for(i = 0; i < asteroidNumber; i++) {
			Vector3 position = new Vector3(Random.Range(-popRange, popRange), Random.Range(-popRange, popRange), Random.Range(-popRange, popRange));
			Vector3 direction = new Vector3(Random.Range(-force, force), Random.Range(-force, force), Random.Range(-force, force));
			GameObject asteroid = Instantiate(prefabAsteroid, position, Quaternion.identity) as GameObject;
			asteroid.transform.localScale = new Vector3(Random.Range(asteroid.transform.localScale.x, asteroid.transform.localScale.x * scale), 
			                                            Random.Range(asteroid.transform.localScale.y, asteroid.transform.localScale.y * scale), 
			             								Random.Range(asteroid.transform.localScale.z, asteroid.transform.localScale.z * scale));
			asteroid.rigidbody.AddForce(transform.TransformDirection(direction) * force);
			asteroid.rigidbody.AddTorque(transform.TransformDirection(direction) * force);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
