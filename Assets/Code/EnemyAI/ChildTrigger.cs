using UnityEngine;
using System.Collections;

public class ChildTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		gameObject.GetComponentInParent<EnemyBehaviour> ().SightTriggered (other);
	}

	void OnTriggerExit(Collider other) {
		gameObject.GetComponentInParent<EnemyBehaviour> ().SightExit (other);
	}
}
