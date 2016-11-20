using UnityEngine;
using System.Collections;

public interface IPuppetState
{
	void UpdateState();
	void OnTriggerEnter (Collider other);
	void OnTriggerExit(Collider other);
	void ToInteractState();
	void ToFollowingState();
	void ToStillState();
	void ToRunningAwayState();
}