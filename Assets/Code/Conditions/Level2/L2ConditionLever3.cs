using UnityEngine;
using System.Collections;

public class L2ConditionLever3 : MonoBehaviour {

	[SerializeField] GameObject attachedObj;

	public bool enable = false;
	public bool puppetReady = false;

	void Update () {
	
	}

	void UseObj() {
		if (enable && puppetReady) {
			attachedObj.GetComponent<DoorBehaviour> ().Use ();
			enable = false;
		}
	}
}
