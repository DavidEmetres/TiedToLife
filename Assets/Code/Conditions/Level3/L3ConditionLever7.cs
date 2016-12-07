using UnityEngine;
using System.Collections;

public class L3ConditionLever7 : MonoBehaviour {
	
	[SerializeField] GameObject attachedObj;

	void Update () {
		if (attachedObj.GetComponent<L3ConditionLever6> ().puppetReady && StatePuppetBehavior.Instance.currentState == StatePuppetBehavior.Instance.stillState) {
			attachedObj.GetComponent<L3ConditionLever6> ().puppetReady = false;
		}
	}

	void UseObj() {
		attachedObj.GetComponent<L3ConditionLever6> ().puppetReady = true;
	}
}
