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

	private void FollowPlayer()
	{
		puppet.target = PlayerController.Instance.transform;
		puppet.navMeshAgent.SetDestination (puppet.target.position);
	}

	public void LookAt()
	{
		Vector3 lookPos = PlayerController.Instance.gameObject.transform.position - puppet.transform.position;
		lookPos.y = 0;
		Quaternion rotation = Quaternion.LookRotation (lookPos);
		puppet.transform.rotation = Quaternion.Slerp (puppet.transform.rotation, rotation, Time.deltaTime * 5f);
	}
}