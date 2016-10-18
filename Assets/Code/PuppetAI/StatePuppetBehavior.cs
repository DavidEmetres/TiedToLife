using UnityEngine;
using System.Collections;

public class StatePuppetBehavior : MonoBehaviour {

	public float followingSpeed;
	public float followingDistance;
	public Vector3 offset = new Vector3 (0, 5f, 0);
	public float sightRange = 500f;
	public Transform player;

	[HideInInspector] public Transform target;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public Collider rangeMax;
	[HideInInspector] public Collider rangeMin;
	[HideInInspector] public IPuppetState currentState;
	[HideInInspector] public StillState stillState;
	[HideInInspector] public FollowingState followingState;
	[HideInInspector] public InteractState interactState;
	[HideInInspector] public NavMeshAgent navMeshAgent;

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

	// Use this for initialization
	void Start ()
	{
		currentState = followingState;
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentState.UpdateState ();
	}

	void OnTriggerEnter(Collider other)
	{
		
	}

	public void ObjectTriggered(Collider other, GameObject objColliding)
	{
		Debug.Log ("Calling State Machine");	
		if (other.tag == "Player" && target == null)
		{
			Debug.Log ("Asignando objetivo");
			target = objColliding.transform;
		}

		currentState.OnTriggerEnter (other);
			
	}

	public void ObjectExit(Collider other, GameObject objColliding)
	{
		if (other.tag == "Player" && target != null)
		{
			Debug.Log ("Desasignando objetivo");
			target = null;
		}

		currentState.OnTriggerExit (other);
	}
		
}