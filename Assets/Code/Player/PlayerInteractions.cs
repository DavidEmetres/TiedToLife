using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if (other.tag == "Lever") {
			if (Input.GetButtonDown ("ActionButton")) {
				other.gameObject.SendMessage ("Use");
			}
		}
		else if (other.tag == "Button") {
			if (Input.GetButtonDown ("ActionButton")) {
				other.gameObject.SendMessage ("Use");
			}
			if (Input.GetButtonUp ("ActionButton")) {
				other.gameObject.SendMessage ("Use");
			}
		}
	}
}
