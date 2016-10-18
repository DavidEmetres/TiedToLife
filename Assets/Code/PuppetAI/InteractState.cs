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
		GoInteract ();
	}

	public void OnTriggerEnter(Collider other)
	{
		
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			ToFollowingState ();
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

	private void GoInteract()
	{
		Debug.Log ("Yendo al boton");
		puppet.navMeshAgent.stoppingDistance = 0;
		pos = puppet.target.position;
		puppet.navMeshAgent.SetDestination (pos);
	}
}