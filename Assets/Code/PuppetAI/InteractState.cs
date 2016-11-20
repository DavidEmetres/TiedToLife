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
<<<<<<< HEAD
		GoInteract ();
=======
		if (Vector3.Distance(puppet.transform.position, puppet.target.transform.position) > puppet.navMeshAgent.stoppingDistance)
			GoInteract ();
		else
			Interact ();

		LookAt ();
>>>>>>> origin/Jose2
	}

	public void OnTriggerEnter(Collider other)
	{
		
	}

	public void OnTriggerExit(Collider other)
	{
<<<<<<< HEAD
		if (other.tag == "Player")
			ToFollowingState ();
=======

>>>>>>> origin/Jose2
	}

	public void ToInteractState()
	{
<<<<<<< HEAD

=======
		//Same state
>>>>>>> origin/Jose2
	}

	public void ToFollowingState()
	{
		puppet.navMeshAgent.stoppingDistance = 4;
		puppet.currentState = puppet.followingState;
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

	private void GoInteract()
	{
<<<<<<< HEAD
		Debug.Log ("Yendo al boton");
		puppet.navMeshAgent.stoppingDistance = 0;
		pos = puppet.target.position;
		puppet.navMeshAgent.SetDestination (pos);
=======
		pos = puppet.target.position;
		puppet.navMeshAgent.SetDestination (pos);
		puppet.navMeshAgent.Resume ();
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
>>>>>>> origin/Jose2
	}
}