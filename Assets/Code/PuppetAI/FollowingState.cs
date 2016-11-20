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
<<<<<<< HEAD
		FollowPlayer ();
		LookAt ();
=======
		if ((PlayerController.Instance.transform.position.y - puppet.transform.position.y) < 3f) {
			FollowPlayer ();
			LookAt ();
		}
>>>>>>> origin/Jose2
	}

	public void OnTriggerEnter(Collider other)
	{
<<<<<<< HEAD
		Debug.Log ("Cambiando estado");
		if (other.tag == "Player")
			ToInteractState ();
=======

>>>>>>> origin/Jose2
	}

	public void OnTriggerExit(Collider other)
	{

	}

	public void ToInteractState()
	{
		puppet.currentState = puppet.interactState;
<<<<<<< HEAD
=======
		puppet.navMeshAgent.stoppingDistance = 1;
>>>>>>> origin/Jose2
	}

	public void ToFollowingState()
	{
<<<<<<< HEAD

=======
		//Same state
>>>>>>> origin/Jose2
	}

	public void ToStillState()
	{
<<<<<<< HEAD
		
=======
		puppet.currentState = puppet.stillState;
	}

	public void ToRunningAwayState() {
		puppet.currentState = puppet.runningAwayState;
>>>>>>> origin/Jose2
	}

	private void FollowPlayer()
	{
<<<<<<< HEAD
		puppet.navMeshAgent.SetDestination (PlayerController.Instance.transform.position);
=======
		puppet.target = PlayerController.Instance.transform;
		puppet.navMeshAgent.SetDestination (puppet.target.position);
		puppet.navMeshAgent.Resume ();
>>>>>>> origin/Jose2
	}

	public void LookAt()
	{
<<<<<<< HEAD
		puppet.transform.LookAt (PlayerController.Instance.transform);
=======
		Vector3 lookPos = PlayerController.Instance.gameObject.transform.position - puppet.transform.position;
		lookPos.y = 0;
		Quaternion rotation = Quaternion.LookRotation (lookPos);
		puppet.transform.rotation = Quaternion.Slerp (puppet.transform.rotation, rotation, Time.deltaTime * 5f);
>>>>>>> origin/Jose2
	}
}