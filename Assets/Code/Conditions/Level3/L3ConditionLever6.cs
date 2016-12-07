using UnityEngine;
using System.Collections;

public class L3ConditionLever6 : MonoBehaviour {

	[SerializeField] GameObject attachedObj;

	public bool puppetReady = false;

	void Update () {
	
	}

	void UseObj() {
		if (puppetReady) {
			attachedObj.GetComponent<ElevatorBehaviour> ().Use ();
			LevelStructure.Instance.NextStep ();
			StatePuppetBehavior.Instance.currentState.ToFollowingState ();
		}
	}
}
