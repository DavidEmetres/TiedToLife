using UnityEngine;
using System.Collections;

public class LeverBehaviour : MonoBehaviour {

	[SerializeField] GameObject attachedObj;
	bool active = false;

	void Update() {
		if (Input.GetKeyDown (KeyCode.LeftShift))
			Use ();
	}

	public void Use() {
		if (!active) {
			attachedObj.SendMessage ("Use");
			active = true;
		}
		else {
			attachedObj.SendMessage ("Use");
			active = false;
		}
	}
}
