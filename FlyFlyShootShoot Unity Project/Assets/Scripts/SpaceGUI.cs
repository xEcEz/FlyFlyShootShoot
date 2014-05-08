using UnityEngine;
using System.Collections;

public class SpaceGUI : MonoBehaviour {
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,20), "Score : " + LeapController.Score);

		// Make the second button.
		//if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
		//	Application.LoadLevel(2);
		//}
	}
}