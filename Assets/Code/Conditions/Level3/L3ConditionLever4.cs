using UnityEngine;
using System.Collections;

public class L3ConditionLever4 : MonoBehaviour {
	
	[SerializeField] GameObject attachedObj;

	void Update () {
		if (attachedObj.GetComponent<L3ConditionLever5> ().puppetReady && StatePuppetBehavior.Instance.currentState == StatePuppetBehavior.Instance.stillState) {
			attachedObj.GetComponent<L3ConditionLever5> ().puppetReady = false;
		}
	}

	void UseObj() {
		attachedObj.GetComponent<L3ConditionLever5> ().puppetReady = true;
	}
}
