using UnityEngine;
using System.Collections;

public class L2ConditionLever4 : MonoBehaviour {
	
	[SerializeField] GameObject attachedObj;

	void Update () {
		if (attachedObj.GetComponent<L2ConditionLever3> ().puppetReady && StatePuppetBehavior.Instance.currentState == StatePuppetBehavior.Instance.stillState) {
			attachedObj.GetComponent<L2ConditionLever3> ().puppetReady = false;
		}
	}

	void UseObj() {
		attachedObj.GetComponent<L2ConditionLever3> ().puppetReady = true;
	}
}
