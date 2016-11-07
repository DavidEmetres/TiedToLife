using UnityEngine;
using System.Collections;

public class RunningAwayState : IPuppetState {

	readonly StatePuppetBehavior puppet;
	Vector3 runningDirection;

	public RunningAwayState(StatePuppetBehavior statePuppetBehavior)
	{
		puppet = statePuppetBehavior;
	}

	public void UpdateState()
	{
		GetRunningDirection ();
		RunAway ();
		FaceDirection ();
	}

	public void OnTriggerEnter(Collider other)
	{

	}

	public void OnTriggerExit(Collider other)
	{

	}

	public void ToInteractState()
	{
		puppet.currentState = puppet.interactState;
		puppet.navMeshAgent.stoppingDistance = 2;
	}

	public void ToFollowingState()
	{

	}

	public void ToStillState()
	{

	}

	public void ToRunningAwayState() {

	}

	void GetRunningDirection() {
		Vector3 newRunningDirection = Vector3.zero;
		foreach (GameObject enemy in puppet.closeEnemies) {
			newRunningDirection += enemy.GetComponent<EnemyBehaviour> ().direction;
		}

		newRunningDirection = newRunningDirection.normalized;
		runningDirection = newRunningDirection;
	}

	void RunAway() {
		puppet.navMeshAgent.Stop ();
		puppet.transform.position += runningDirection * puppet.navMeshAgent.speed * Time.deltaTime;

	}

	void FaceDirection()
	{
		Quaternion rotation = Quaternion.LookRotation (runningDirection);
		puppet.transform.rotation = Quaternion.Slerp (puppet.transform.rotation, rotation, Time.deltaTime * 5f);
	}
}
