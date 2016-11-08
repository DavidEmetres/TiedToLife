using UnityEngine;
using System.Collections;

public class StillState : IPuppetState
{
	private readonly StatePuppetBehavior puppet;

	public StillState(StatePuppetBehavior statePuppetBehavior)
	{
		puppet = statePuppetBehavior;
	}

	public void UpdateState()
	{
		puppet.navMeshAgent.Stop ();
	}

	public void OnTriggerEnter(Collider other)
	{
		
	}

	public void OnTriggerExit(Collider other)
	{

	}

	public void ToInteractState()
	{
		//Not possible
	}

	public void ToFollowingState()
	{
		puppet.navMeshAgent.stoppingDistance = 4;
		puppet.currentState = puppet.followingState;
	}

	public void ToStillState()
	{
		//Same state
	}

	public void ToRunningAwayState() {
		//Not possible
	}
}