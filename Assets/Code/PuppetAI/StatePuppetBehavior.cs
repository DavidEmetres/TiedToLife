using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatePuppetBehavior : MonoBehaviour {

	GameObject objectInteractingNow;

	public float followingSpeed;
	//public float followingDistance;
	//public Vector3 offset = new Vector3 (0, 5f, 0);
	//public float sightRange = 500f;
	//public Transform player;

	public List<GameObject> objectsInSight = new List<GameObject> ();
	[HideInInspector] public Transform target;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public Collider rangeMax;
	[HideInInspector] public Collider rangeMin;
	[HideInInspector] public IPuppetState currentState;
	[HideInInspector] public StillState stillState;
	[HideInInspector] public FollowingState followingState;
	[HideInInspector] public InteractState interactState;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public bool isGrabbed = true;

	public static StatePuppetBehavior Instance;

	void Awake()
	{
		Instance = this;

		target = null;
		interactState = new InteractState (this);
		followingState = new FollowingState (this);
		stillState = new StillState (this);

		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	void Start ()
	{
		currentState = followingState;
	}
	
	void Update ()
	{
		Debug.Log (currentState);
		currentState.UpdateState ();

		if (objectsInSight.Count > 0)
			Evaluation ();

		if (isGrabbed) {
			if (Vector3.Distance (this.transform.position, PlayerController.Instance.gameObject.transform.position) > navMeshAgent.stoppingDistance) {
				if (navMeshAgent.destination != null) {
					navMeshAgent.Stop ();
					transform.position = Vector3.Slerp (transform.position, PlayerController.Instance.gameObject.transform.position, Time.deltaTime);
				}
			} else if (navMeshAgent.destination != null)
				navMeshAgent.Resume ();
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			if (isGrabbed)
				isGrabbed = false;
			else
				isGrabbed = true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		
	}

	public void ObjectTriggered(Collider other, GameObject objColliding)
	{
		if (other.tag == "interactive")
		{
			if(!objectsInSight.Contains(objColliding))
				objectsInSight.Add (objColliding);
		}
	}

	public void ObjectExit(Collider other, GameObject objColliding)
	{
		if (other.tag == "interactive")
		{
			Debug.Log (objColliding.name + " SALIO DEL COLLIDER");
			if (objColliding == target.gameObject) {
				currentState.ToFollowingState ();
				objectInteractingNow = null;
			}

			objectsInSight.Remove (objColliding);
		}
	}

	void Evaluation() {
		foreach (GameObject obj in objectsInSight) {
			if (LevelStructure.Instance.GetPriority (obj) == 0) {
				if (objectInteractingNow != obj) {
					objectInteractingNow = obj;
					obj.GetComponent<InteractiveBehaviour> ().currentState = obj.GetComponent<InteractiveBehaviour> ().defaultState;
					currentState.ToInteractState ();
					target = obj.transform;
					break;
				}
			}
		}
	}
}