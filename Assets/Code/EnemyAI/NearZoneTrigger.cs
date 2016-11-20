using UnityEngine;
using System.Collections;

public class NearZoneTrigger : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		gameObject.GetComponentInParent<EnemyBehaviour> ().NearZoneTriggered (other);
	}
}
