using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public Transform[] wayPoints;
	public bool[] stops;
	public float stopTime = 4f;
	public bool occluded = false;
	public bool puppetOccluded = false;
	public LayerMask rayCastLayer;
	public bool stunned = false;
	[HideInInspector] public Vector3 direction;
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
		if (!stunned) {
			if (!sight.gameObject.activeInHierarchy)
				sight.gameObject.SetActive (true);
			
			currentState.UpdateState ();
			CheckObstacles ();
			CheckObstaclesPuppet ();
			Debug.DrawRay (transform.position, (PlayerController.Instance.transform.position - transform.position));
			Debug.DrawRay (transform.position, (StatePuppetBehavior.Instance.transform.position - transform.position));
		} else {
			nav.Stop ();
			sight.gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider other) {
		
	}

	void CheckObstacles() {
		Vector3 pos = new Vector3 (PlayerController.Instance.transform.position.x, transform.position.y, PlayerController.Instance.transform.position.z);
		Vector3 direction = pos - transform.position;
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

	void CheckObstaclesPuppet() {
		Vector3 pos = new Vector3 (StatePuppetBehavior.Instance.transform.position.x, transform.position.y, StatePuppetBehavior.Instance.transform.position.z);
		Vector3 direction = pos - transform.position;
		Ray ray = new Ray (transform.position, direction);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, rayCastLayer)) {
			if (hit.transform.tag == "Puppet") {
				puppetOccluded = false;
			}
			else
				puppetOccluded = true;
		}
		else
			puppetOccluded = true;
	}

	public void SightTriggered(Collider other) {
		if (other.tag == "Player" && target == null) {
			target = PlayerController.Instance.gameObject.transform;
		}

		if (other.tag == "Puppet" && !puppetOccluded) {
			StatePuppetBehavior.Instance.GrabPuppet (false);
			StatePuppetBehavior.Instance.currentState.ToStillState ();
		}

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
