using UnityEngine;
using System.Collections;

public class ConditionElevator : MonoBehaviour {

	[SerializeField] GameObject[] attachedObjs;
	public bool added = false;

	void Update () {
		if (GetComponent<ElevatorBehaviour> ().isReady)
			added = false;

		if (!GetComponent<ElevatorBehaviour> ().isReady && GetComponent<ElevatorBehaviour> ().up && PlayerController.Instance.transform.position.y <= 2f) {
			GetComponent<ElevatorBehaviour> ().Use ();

			if (!attachedObjs [0].GetComponent<ConditionLever2> ().active && !added) {
				LevelStructure.Instance.AddNextAction (attachedObjs [1]);
				StatePuppetBehavior.Instance.objectInteractingNow = null;
				StatePuppetBehavior.Instance.objectsInSight.Add (attachedObjs [1]);
				attachedObjs [1].GetComponent<InteractiveBehaviour> ().currentState = 1;
				added = true;
			}
		}
	}
}
