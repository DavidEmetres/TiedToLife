using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if (other.tag == "interactive") {
			if (Input.GetButtonDown ("ActionButton")) {
				other.gameObject.SendMessage ("Use");
			}
		}
	}
}
