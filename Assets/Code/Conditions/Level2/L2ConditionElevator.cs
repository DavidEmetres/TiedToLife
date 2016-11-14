using UnityEngine;
using System.Collections;

public class L2ConditionElevator : MonoBehaviour {

	[SerializeField] GameObject[] attachedObjs;

	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.GetType ());
		if (other.tag == "Player" && other.GetType() == typeof(CapsuleCollider)) {
			LevelStructure.Instance.NextStep ();
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			if (!attachedObjs [1].GetComponent<L2ConditionLever5> ().active) {
				LevelStructure.Instance.AddNextAction (attachedObjs [0]);
			}
		}
	}
}
