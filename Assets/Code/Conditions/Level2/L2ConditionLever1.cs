using UnityEngine;
using System.Collections;

public class L2ConditionLever1 : MonoBehaviour {

	[SerializeField] GameObject attachedObj;

	void Update () {
		if (attachedObj.GetComponent<L2ConditionLightArea> ().enemiesInArea.Count > 0) {
			if (this.GetComponent<InteractiveBehaviour> ().currentState != -1) {
				this.GetComponent<InteractiveBehaviour> ().currentState = 0;
			}
		}
	}

	void UseObj() {
		attachedObj.GetComponent<L2ConditionLightArea> ().active = true;
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Puppet") {
			attachedObj.GetComponent<L2ConditionLightArea> ().active = false;
		}
	}
}
