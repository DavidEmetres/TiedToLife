using UnityEngine;
using System.Collections;

public class SightTrigger : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		gameObject.GetComponentInParent<EnemyBehaviour> ().SightTriggered (other);
	}

	void OnTriggerExit(Collider other) {
		gameObject.GetComponentInParent<EnemyBehaviour> ().SightExit (other);
	}
}
