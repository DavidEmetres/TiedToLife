using UnityEngine;
using System.Collections;

public class ConditionLever3 : MonoBehaviour {

	[SerializeField] ConditionLever2 attachedObj;

	void Update () {
		if (attachedObj.isReady && StatePuppetBehavior.Instance.currentState == StatePuppetBehavior.Instance.stillState) {
			attachedObj.isReady = false;
		}
	}

	public void UseObj() {
		attachedObj.isReady = true;
	}
}
