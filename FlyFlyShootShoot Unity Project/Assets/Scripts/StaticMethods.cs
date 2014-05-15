using UnityEngine;
using System.Collections;

public class StaticMethods : MonoBehaviour {

	public static bool Pause = false;

	public static void SetOnPause(){
		if (!Pause) {
			Pause = true;
		}
	}

	public static void SetOnPlay(){
		if (Pause) {
			Pause = false;
		}
	}
}
