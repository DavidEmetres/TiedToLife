using UnityEngine;
using System.Collections;

public class ConditionExitCollider : MonoBehaviour {

	[SerializeField] GameObject attachedObj;

	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Application.LoadLevel ("Level2");
		}
	}
}
