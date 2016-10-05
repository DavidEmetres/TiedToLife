using UnityEngine;
using System.Collections;

public class PatrolState : IEnemy {

	EnemyBehaviour enemy;
	int nextWayPoint = 0;

	public PatrolState (EnemyBehaviour enemy) {
		this.enemy = enemy;
	}

	public void UpdateState () {
		Patrol ();
	}

	public void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			enemy.currentState = enemy.chaseState;
		}
	}

	public void ToPatrolState() {
		
	}

	public void ToAlertState() {
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState() {
		enemy.currentState = enemy.chaseState;
	}

	void Patrol() {
		enemy.nav.SetDestination (enemy.wayPoints [nextWayPoint].position);

		if (Vector3.Distance (enemy.transform.position, enemy.wayPoints [nextWayPoint].position) < 2f) {
			if (nextWayPoint < enemy.wayPoints.Length-1)
				nextWayPoint++;
			else
				nextWayPoint = 0;
		}
	}
}
