using UnityEngine;
using System.Collections;

public class L3ConditionLever5 : MonoBehaviour {

	[SerializeField] GameObject attachedObj;
	bool next = false;

	public bool puppetReady = false;

	void Update () {
	
	}

	void UseObj() {
		if (puppetReady) {
			attachedObj.GetComponent<DoorBehaviour> ().Use ();
			if (!next) {
				next = true;
				LevelStructure.Instance.NextStep ();
				StatePuppetBehavior.Instance.currentState.ToFollowingState ();
			}
		}
	}
}
