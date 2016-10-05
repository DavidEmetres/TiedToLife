using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public Transform[] wayPoints;
	public bool[] stops;
	public float stopTime = 4f;
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
	}

	void Start() {
		currentState = patrolState;
	}

	void Update() {
		currentState.UpdateState ();
	}
}
