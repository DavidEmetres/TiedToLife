using UnityEngine;
using System.Collections;

public class ConditionDoor : MonoBehaviour {

	[SerializeField] GameObject attachedObj;

	void Update () {
		if (GetComponentInParent<DoorBehaviour> ().open)
			attachedObj.SetActive (true);
		else
			attachedObj.SetActive (false);
	}
}
