using UnityEngine;
using System.Collections;

public class ObjectTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		StatePuppetBehavior.Instance.ObjectTriggered (other, this.gameObject);
	}

	void OnTriggerExit(Collider other) {
		StatePuppetBehavior.Instance.ObjectExit (other, this.gameObject);
	}
}