using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	public float openAngle = 160f;
	public Transform rotationPoint;
	public bool open = false;
	bool isLerping = false;
	float timeStartedLerping;
	Vector3 startPosition;
	Vector3 endPosition;

	public Vector3 upPos;
	public Vector3 defaultPos;
	public float timeTakenDuringLerp;
	public bool isReady = false;

	public void Use() {
		if(!isLerping && !open)
			StartLerping ();
	}

	void StartLerping()
	{
		isLerping = true;
		timeStartedLerping = Time.time;

		if (!open) {
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

			//transform.localPosition = Vector3.Lerp (startPosition, endPosition, percentageComplete);
			transform.RotateAround(rotationPoint.position, Vector3.up, 2f);

			if(transform.eulerAngles.y >= openAngle)
			{
				isLerping = false;
				open = true;
			}
		}
	}
}
