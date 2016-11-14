using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatePuppetBehavior : MonoBehaviour {

	GameObject objectInteractingNow;
	float puppetTimer;

	public float puppetLifeTime;
	public float followingSpeed;
	public float closerDistanceToEnemies;
	[HideInInspector] public List<GameObject> closeEnemies = new List<GameObject> ();
	[HideInInspector] public List<GameObject> objectsInSight = new List<GameObject> ();
	[HideInInspector] public Transform target;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public Collider rangeMax;
	[HideInInspector] public Collider rangeMin;
	[HideInInspector] public IPuppetState currentState;
	[HideInInspector] public StillState stillState;
	[HideInInspector] public FollowingState followingState;
	[HideInInspector] public InteractState interactState;
	[HideInInspector] public RunningAwayState runningAwayState;
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
		runningAwayState = new RunningAwayState (this);

		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	void Start ()
	{
		currentState = followingState;
	}
	
	void Update ()
	{
		currentState.UpdateState ();
		Debug.Log (currentState);
		if (currentState != stillState) {
			if (GetCloseEnemies ()) {
				currentState.ToRunningAwayState ();
			}
			else {
				if (objectsInSight.Count > 0)
					Evaluation ();

				if (objectInteractingNow == null)
					currentState.ToFollowingState ();
			}

			//PUPPET GRABBED BEHAVIOUR
			if (isGrabbed) {
				if (Vector3.Distance (this.transform.position, PlayerController.Instance.gameObject.transform.position) > navMeshAgent.stoppingDistance) {
					if (navMeshAgent.destination != null) {
						navMeshAgent.Stop ();
						transform.position = Vector3.Slerp (transform.position, PlayerController.Instance.gameObject.transform.position, Time.deltaTime);
					}
				}
				else if (navMeshAgent.destination != null)
					navMeshAgent.Resume ();
			}

		//PUPPET LIFE TIMER
		else {
				if (Time.realtimeSinceStartup >= puppetTimer) {
					currentState.ToStillState ();
				}
			}
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
			if (objColliding == target.gameObject) {
				if(currentState != runningAwayState)
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

	bool GetCloseEnemies() {
		foreach (GameObject enemy in LevelStructure.Instance.GetEnemiesInLevel()) {
			float distance = Vector3.Distance (transform.position, enemy.transform.position);

			if (distance <= closerDistanceToEnemies && EnemyGettingCloser(enemy)) {
				if (!closeEnemies.Contains (enemy) && !enemy.GetComponent<EnemyBehaviour>().puppetOccluded)
					closeEnemies.Add (enemy);
			}
			else {
				if (closeEnemies.Contains(enemy))
					closeEnemies.Remove (enemy);
			}
		}

		return closeEnemies.Count > 0;
	}

	bool EnemyGettingCloser(GameObject enemy) {
		Vector3 directionEnemyPlayer = transform.position - enemy.transform.position;

		if (Vector3.Angle (directionEnemyPlayer, enemy.GetComponent<EnemyBehaviour> ().direction) <= 40f) {
			return true;
		}
		else
			return false;
	}

	public void GrabPuppet(bool b) {
		if (!b)
			puppetTimer = Time.realtimeSinceStartup + puppetLifeTime;
		else if (currentState == stillState)
			currentState.ToFollowingState ();
		
		isGrabbed = b;
	}

	void OnGUI() {
		float lifeTime = (isGrabbed)? puppetLifeTime : (puppetTimer - Time.realtimeSinceStartup);
		GUI.Label (new Rect (100, 100, 100, 100), "LIFE TIME: " + lifeTime);
	}
}