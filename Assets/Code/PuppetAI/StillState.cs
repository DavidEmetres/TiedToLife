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
<<<<<<< HEAD
		
=======
		puppet.navMeshAgent.Stop ();
>>>>>>> origin/Jose2
	}

	public void OnTriggerEnter(Collider other)
	{
		
	}

	public void OnTriggerExit(Collider other)
	{

	}

	public void ToInteractState()
	{
<<<<<<< HEAD

=======
		puppet.currentState = puppet.interactState;
		puppet.navMeshAgent.stoppingDistance = 1;
>>>>>>> origin/Jose2
	}

	public void ToFollowingState()
	{
<<<<<<< HEAD

=======
		puppet.navMeshAgent.stoppingDistance = 4;
		puppet.currentState = puppet.followingState;
>>>>>>> origin/Jose2
	}

	public void ToStillState()
	{
<<<<<<< HEAD

	}

	private void LogStill()
	{
		
=======
		//Same state
	}

	public void ToRunningAwayState() {
		//Not possible
>>>>>>> origin/Jose2
	}
}