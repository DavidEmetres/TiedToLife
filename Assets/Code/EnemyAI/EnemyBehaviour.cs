using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public Vector3 direction;
	public Transform[] wayPoints;
	public bool[] stops;
	public float stopTime = 4f;
	public bool occluded = false;
	public LayerMask rayCastLayer;
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

		CheckObstacles ();
		Debug.DrawRay (transform.position, (PlayerController.Instance.transform.position - transform.position));
	}

	void OnTriggerEnter(Collider other) {
		
	}

	void CheckObstacles() {
		Vector3 direction = PlayerController.Instance.transform.position - transform.position;
		Ray ray = new Ray (transform.position, direction);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, rayCastLayer)) {
			if (hit.transform.tag == "Player") {
				occluded = false;
			}
			else
				occluded = true;
		}
		else
			occluded = true;
	}

	public void SightTriggered(Collider other) {
		if (other.tag == "Player" && target == null)
			target = PlayerController.Instance.gameObject.transform;

		currentState.OnSightTriggerEnter (other);
	}

	public void SightExit(Collider other) {
		if (other.tag == "Player" && target != null)
			target = null;

		currentState.OnSightTriggerExit (other);
	}

	public void NearZoneTriggered(Collider other) {
		currentState.OnNearZoneTriggerEnter (other);
	}
}
