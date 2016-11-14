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
			attachedObjs [2].GetComponent<InteractiveBehaviour> ().currentState = 0;
			isReady = false;
			StatePuppetBehavior.Instance.objectsInSight.Add (attachedObjs [2]);
			LevelStructure.Instance.NextStep ();
			StatePuppetBehavior.Instance.currentState.ToFollowingState ();
		}
	}
}
