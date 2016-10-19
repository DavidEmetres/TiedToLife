using UnityEngine;
using System.Collections;

public class FollowingState : IPuppetState
{

	private readonly StatePuppetBehavior puppet;
	private float distance;

	public FollowingState(StatePuppetBehavior statePuppetBehavior)
	{
		puppet = statePuppetBehavior;
	}

	public void UpdateState()
	{
		FollowPlayer ();
		LookAt ();
	}

	public void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Cambiando estado");
		if (other.tag == "Player")
			ToInteractState ();
	}

	public void OnTriggerExit(Collider other)
	{

	}

	public void ToInteractState()
	{
		puppet.currentState = puppet.interactState;
	}

	public void ToFollowingState()
	{

	}

	public void ToStillState()
	{
		
	}

	private void FollowPlayer()
	{
		puppet.navMeshAgent.SetDestination (PlayerController.Instance.transform.position);
	}

	public void LookAt()
	{
		puppet.transform.LookAt (PlayerController.Instance.transform);
	}
}