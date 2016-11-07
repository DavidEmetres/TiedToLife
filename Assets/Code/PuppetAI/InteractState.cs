using UnityEngine;
using System.Collections;

public class InteractState : IPuppetState
{
	private readonly StatePuppetBehavior puppet;

	Vector3 pos;
	bool somethingNear;

	public InteractState(StatePuppetBehavior statePuppetBehavior)
	{
		puppet = statePuppetBehavior;
	}

	public void UpdateState()
	{
		if (Vector3.Distance(puppet.transform.position, puppet.target.transform.position) > puppet.navMeshAgent.stoppingDistance)
			GoInteract ();
		else
			Interact ();

		LookAt ();
	}

	public void OnTriggerEnter(Collider other)
	{
		
	}

	public void OnTriggerExit(Collider other)
	{

	}

	public void ToInteractState()
	{

	}

	public void ToFollowingState()
	{
		puppet.navMeshAgent.stoppingDistance = 4;
		puppet.currentState = puppet.followingState;
	}

	public void ToStillState()
	{

	}

	public void ToRunningAwayState() {
		puppet.currentState = puppet.runningAwayState;
	}

	private void GoInteract()
	{
		pos = puppet.target.position;
		puppet.navMeshAgent.SetDestination (pos);
	}

	void Interact() {
		if (puppet.target.gameObject.GetComponent<InteractiveBehaviour> ().currentState == 0) {
			puppet.target.gameObject.GetComponent<InteractiveBehaviour> ().Use ();
		}
	}

	public void LookAt()
	{
		Vector3 lookPos = puppet.target.position - puppet.transform.position;
		lookPos.y = 0;
		Quaternion rotation = Quaternion.LookRotation (lookPos);
		puppet.transform.rotation = Quaternion.Slerp (puppet.transform.rotation, rotation, Time.deltaTime * 5f);
	}
}