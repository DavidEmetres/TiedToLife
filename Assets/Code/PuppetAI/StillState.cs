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

	}

	public void ToStillState()
	{

	}

	private void LogStill()
	{
		
	}
}