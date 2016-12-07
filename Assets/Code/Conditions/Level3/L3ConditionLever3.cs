using UnityEngine;
using System.Collections;

public class L3ConditionLever3 : MonoBehaviour {

	[SerializeField] GameObject attachedObj;
	float timer = 0f;

	public float lightTime = 5f;

	void Update () {
		timer += Time.deltaTime;

		if (timer >= lightTime) {
			attachedObj.SetActive (false);
		}
	}

	void UseObj() {
		attachedObj.SetActive (true);
		timer = 0f;
	}
}
