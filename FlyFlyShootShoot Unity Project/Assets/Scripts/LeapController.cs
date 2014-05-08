using UnityEngine;
using System.Collections;
using Leap;

public class LeapController : MonoBehaviour {
	
	public static int Score = 0;
	public static GameObject FlyShoo;
	
	static int shootTimeDelta = 100;
	
	public Camera inside;
	public Camera outside;
	public int cameraNumber;
	
	public float speedScale;
	public float pitchScale;
	public float rawScale;
	
	public GameObject weapon;
	public float weaponForce = 30000;

	public bool leapEnabled;
	float speedNoLeap = 0;
	public float speedScaleNoLeap;
	public float pitchScaleNoLeap;
	public float rawScaleNoLeap;
	static int cameraDelta = 50;
	int lastCamera = cameraDelta;
	
	Controller leapController;
	CharacterController controller;
	
	int leftHandID = -1;
	int rightHandID = -1;

	int lastShoot = shootTimeDelta;
	
	float pitch;
	float raw;
	
	// Use this for initialization
	void Start () {
		if (cameraNumber == 1) {
						inside.enabled = true;
						outside.enabled = false;
				} else if (cameraNumber == 3) {
						inside.enabled = false;
						outside.enabled = true;
				} 
		
		leapController = new Controller();
		controller = GetComponent<CharacterController>();
		
		FlyShoo = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		lastShoot ++;
		if (leapEnabled) {
			Frame frame = leapController.Frame();
			pitch = 0;
			raw  = 0;
			if (frame.Hands.Count > 1) {
					Hand leftHand = GetLeftMostHand (frame);
					Hand rightHand = GetRightMostHand (frame);

					int fingersNumber = leftHand.Fingers.Count + rightHand.Fingers.Count;

					pitch = pitchScale * ((leftHand.Direction.Pitch + rightHand.Direction.Pitch) / 2f - 0.25f);
					raw = rawScale * (leftHand.PalmPosition.y - rightHand.PalmPosition.y);
					Vector3 newRot = new Vector3 (-pitch, raw, -raw);

					transform.Rotate (newRot);
					print (newRot);
					float speed = -speedScale * (leftHand.PalmPosition.Normalized.z + rightHand.PalmPosition.Normalized.z) * 0.5f;
					controller.Move (transform.TransformDirection (Vector3.forward * speed));
					print (transform.TransformDirection (Vector3.forward * speed));

					
					if (fingersNumber < 5) {
							shoot ();
					}
			}
		} else {
			if(Input.GetKey(KeyCode.W)) {
				pitch -= pitchScaleNoLeap;
			}
			if(Input.GetKey(KeyCode.S)) {
				pitch += pitchScaleNoLeap;
			}
			if(Input.GetKey(KeyCode.A)) {
				raw -= rawScaleNoLeap;
			}
			if(Input.GetKey(KeyCode.D)) {
				raw += rawScaleNoLeap;
			}
			Vector3 newRot = new Vector3 (-pitch, raw, -raw);
			transform.Rotate(newRot);
			if(Input.GetKey(KeyCode.Q)) {
				speedNoLeap += speedScaleNoLeap;
			}
			if(Input.GetKey(KeyCode.E)) {
				speedNoLeap -= speedScaleNoLeap;
			}
			controller.Move(transform.TransformDirection(Vector3.forward * speedNoLeap));
			if (Input.GetKey(KeyCode.Space)) {
				print ("SPACE");
				shoot();
			}
		}

		if(Input.GetKey(KeyCode.C) && lastCamera > cameraDelta) {
			inside.enabled = !inside.enabled;
			outside.enabled = !outside.enabled;
			lastCamera = 0;
		}
		lastCamera++;

	}
	
	Hand GetLeftMostHand(Frame f) {
		Hand res = f.Hands.Leftmost;
		if (leftHandID != -1 && f.Hand (leftHandID).IsValid) {
			res = f.Hand(leftHandID);
		}else{
			leftHandID = res.Id;	
		}
		return res;
	}
	
	Hand GetRightMostHand(Frame f) {
		Hand res = f.Hands.Rightmost;
		if (rightHandID != -1 && f.Hand (rightHandID).IsValid) {
			res = f.Hand(rightHandID);
		}else{
			rightHandID = res.Id;	
		}
		return res;
	}
	
	void shoot() {
		if (lastShoot > shootTimeDelta){ 
			print ("SHOOT");
			GameObject clone = Instantiate(weapon, weapon.rigidbody.position + 5*transform.TransformDirection(Vector3.down), weapon.rigidbody.rotation) as GameObject;
			clone.rigidbody.AddForce(transform.TransformDirection(Vector3.forward * weaponForce));
			lastShoot = 0;
		}
	}	
}