using UnityEngine;
using System.Collections;

public class ElevatorBehaviour : MonoBehaviour {

	bool up = false;
	bool isLerping = false;
	float timeStartedLerping;
	Vector3 startPosition;
	Vector3 endPosition;

	public Vector3 upPos;
	public Vector3 defaultPos;
	public float timeTakenDuringLerp;
	public bool isReady = false;

	public void Use() {
		if(!isLerping)
			StartLerping ();
	}

	void StartLerping()
	{
		isLerping = true;
		timeStartedLerping = Time.time;

		if (!up) {
			startPosition = defaultPos;
			endPosition = upPos;
		}
		else {
			startPosition = upPos;
			endPosition = defaultPos;
		}
	}

	void FixedUpdate()
	{
		if(isLerping)
		{
			float timeSinceStarted = Time.time - timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			transform.localPosition = Vector3.Lerp (startPosition, endPosition, percentageComplete);

			if(percentageComplete >= 1.0f)
			{
				isLerping = false;
				up = !up;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			isReady = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			isReady = false;
		}
	}
}
