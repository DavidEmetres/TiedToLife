using UnityEngine;
using System.Collections;

public class ConditionLever2 : MonoBehaviour {

	[SerializeField] GameObject[] attachedObjs;

	public bool isReady = false;

	void Update () {

	}

	public void UseObj() {
		if (isReady) {
			attachedObjs[0].GetComponent<ElevatorBehaviour> ().Use ();
			attachedObjs [1].GetComponent<InteractiveBehaviour> ().currentState = -1;
			StatePuppetBehavior.Instance.objectsInSight.Add (attachedObjs [2]);
			isReady = false;
			LevelStructure.Instance.NextStep ();
			StatePuppetBehavior.Instance.currentState.ToFollowingState ();
		}
	}
}
