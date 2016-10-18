using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	[SerializeField] GameObject attachedObj;
	bool up = false;
	bool isLerping = false;
	float timeStartedLerping;
	Vector3 startPosition;
	Vector3 endPosition;

	public Vector3 upPos;
	public Vector3 defaultPos;
	public float timeTakenDuringLerp;

	public void Use() {
		StartLerping ();
	}

	void StartLerping()
	{
		isLerping = true;
		timeStartedLerping = Time.time;

		if (!up) {
			startPosition = this.transform.position;
			endPosition = upPos;
			up = false;
		}
		else {
			startPosition = this.transform.position;
			endPosition = defaultPos;
			up = true;
		}
	}

	void FixedUpdate()
	{
		if(isLerping)
		{
			float timeSinceStarted = Time.time - timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			transform.position = Vector3.Lerp (startPosition, endPosition, percentageComplete);

			if(percentageComplete >= 1.0f)
			{
				isLerping = false;
			}
		}
	}
}
