using UnityEngine;
using System.Collections;

public class L2ConditionElevator : MonoBehaviour {

	[SerializeField] GameObject[] attachedObjs;

	void Update () {
		if (GetComponentInParent<ElevatorBehaviour> ().isReady && GetComponentInParent<ElevatorBehaviour> ().up && attachedObjs [1].GetComponent<L2ConditionLever5> ().active) {
			GetComponentInParent<ElevatorBehaviour> ().Use ();
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.GetType ());
		if (other.tag == "Player" && other.GetType() == typeof(CapsuleCollider)) {
			if (!attachedObjs [1].GetComponent<L2ConditionLever5> ().active && PlayerController.Instance.transform.position.y < 3f) {
				LevelStructure.Instance.NextStep ();
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player" && other.GetType() == typeof(CapsuleCollider)) {
			if (!attachedObjs [1].GetComponent<L2ConditionLever5> ().active && (PlayerController.Instance.transform.position.y < 3f)) {
				LevelStructure.Instance.AddNextAction (attachedObjs [0]);
				StatePuppetBehavior.Instance.objectsInSight.Add (attachedObjs [0]);
			}
		}
	}
}
