using UnityEngine;
using System.Collections;

public class L2ConditionLever5 : MonoBehaviour {

	[SerializeField] GameObject attachedObject;
	public bool active = false;

	void Update () {
	
	}

	void UseObj() {
		if (!active) {
			active = true;
			attachedObject.GetComponent<L2ConditionLever3> ().enable = true;
		}
	}
}
