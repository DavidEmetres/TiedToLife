using UnityEngine;
using System.Collections;

public class ConditionLever3 : MonoBehaviour {

	[SerializeField] ConditionLever2 attachedObj;

	void Update () {

	}

	public void UseObj() {
		attachedObj.isReady = true;
	}
}
