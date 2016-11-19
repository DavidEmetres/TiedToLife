using UnityEngine;
using System.Collections;

public class PuppetSightTrigger: MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		transform.parent.GetComponent<StatePuppetBehavior>().ObjectTriggered (other, other.gameObject);
	}

	void OnTriggerExit(Collider other) {
		transform.parent.GetComponent<StatePuppetBehavior>().ObjectExit (other, other.gameObject);
	}
}