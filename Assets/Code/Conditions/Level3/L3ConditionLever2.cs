using UnityEngine;
using System.Collections;

public class L3ConditionLever2 : MonoBehaviour {

	[SerializeField] GameObject[] attachedObj;
	bool next = false;

	public bool active = false;

	void Update () {

	}

	public void UseObj() {
		attachedObj[0].GetComponent<ElevatorBehaviour> ().Use ();
		active = true;
		if (!next) {
			next = true;
			attachedObj [1].GetComponent<InteractiveBehaviour> ().currentState = attachedObj [1].GetComponent<InteractiveBehaviour> ().defaultState;
			LevelStructure.Instance.AddNextAction (attachedObj [1]);
			StatePuppetBehavior.Instance.objectInteractingNow = null;
			StatePuppetBehavior.Instance.objectsInSight.Add (attachedObj [1]);
		}
	}
}
