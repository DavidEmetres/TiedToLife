using UnityEngine;
using System.Collections;

public class L2ConditionLever2 : MonoBehaviour {

	[SerializeField] GameObject attachedObj;

	void Update () {
		if (this.gameObject.GetComponent<InteractiveBehaviour> ().currentState != -1) {
			if (attachedObj.GetComponent<ElevatorBehaviour> ().isReady)
				this.gameObject.GetComponent<InteractiveBehaviour> ().currentState = 0;
		}
	}

	public void UseObj() {
		attachedObj.GetComponent<ElevatorBehaviour> ().Use ();
		this.gameObject.GetComponent<InteractiveBehaviour> ().currentState = -1;
		LevelStructure.Instance.NextStep();
		StatePuppetBehavior.Instance.currentState.ToFollowingState ();
	}
}
