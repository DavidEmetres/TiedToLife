using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public Transform[] wayPoints;
	public bool[] stops;
	public float stopTime = 4f;
	[HideInInspector] public Transform target;
	[HideInInspector] public Animator sightAnim;
	[HideInInspector] public MeshRenderer sight;
	[HideInInspector] public NavMeshAgent nav;
	[HideInInspector] public IEnemy currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public ChaseState chaseState;

	void Awake() {
		patrolState = new PatrolState (this);
		alertState = new AlertState (this);
		chaseState = new ChaseState (this);

		nav = GetComponent<NavMeshAgent> ();
		sight = transform.GetChild (1).GetChild (0).gameObject.GetComponent<MeshRenderer> ();
		sightAnim = transform.GetChild (1).gameObject.GetComponent<Animator> ();
	}

	void Start() {
		currentState = patrolState;
	}

	void Update() {
		currentState.UpdateState ();
	}

	void OnTriggerEnter(Collider other) {
		currentState.OnTriggerEnter (other);
	}

	public void SightTriggered(Collider other) {
		if (other.tag == "Player" && target == null)
			target = PlayerController.Instance.gameObject.transform;

		currentState.OnTriggerEnter (other);
	}

	public void SightExit(Collider other) {
		if (other.tag == "Player" && target != null)
			target = null;

		currentState.OnTriggerExit (other);
	}
}
