using UnityEngine;
using System.Collections;

public class ChildTriggerElevator : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GetComponentInParent<ElevatorBehaviour> ().isReady = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			GetComponentInParent<ElevatorBehaviour> ().isReady = false;
		}
	}
}
