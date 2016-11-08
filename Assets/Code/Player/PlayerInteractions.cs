using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {

	bool puppetClose = false;

	void Update() {
		if (Input.GetButtonDown ("GrabButton")) {
			if (StatePuppetBehavior.Instance.isGrabbed)
				StatePuppetBehavior.Instance.GrabPuppet (false);
			else if (!StatePuppetBehavior.Instance.isGrabbed && puppetClose)
				StatePuppetBehavior.Instance.GrabPuppet (true);
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "interactive") {
			if (Input.GetButtonDown ("ActionButton")) {
				other.gameObject.SendMessage ("Use");
			}
		}

		if (other.tag == "Puppet") {
				puppetClose = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Puppet") {
			puppetClose = false;
		}
	}
}
