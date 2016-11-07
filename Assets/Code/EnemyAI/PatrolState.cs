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
		UpdateSight ();

		enemy.direction = enemy.nav.destination - enemy.transform.position;
	}

	public void OnSightTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (!enemy.occluded)
				ToChaseState ();
		}
	}

	public void OnSightTriggerExit(Collider other) {
		//Not used
	}

	public void OnNearZoneTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			ToAlertState ();
		}
	}

	public void ToPatrolState() {
		//Cant change to same state
	}

	public void ToAlertState() {
		enemy.currentState = enemy.alertState;
		enemy.sightAnim.SetTrigger ("Alerting");
		enemy.nav.Stop ();
	}

	public void ToChaseState() {
		enemy.currentState = enemy.chaseState;
	}

	void Patrol() {
		enemy.nav.SetDestination (enemy.wayPoints [nextWayPoint].position);

		if (Vector3.Distance (enemy.transform.position, enemy.wayPoints [nextWayPoint].position) < 2f) {
			if (enemy.stops [nextWayPoint]) {
				if (nextWayPoint < enemy.wayPoints.Length - 1)
					nextWayPoint++;
				else
					nextWayPoint = 0;
				
				ToAlertState ();
			}
			else {
				if (nextWayPoint < enemy.wayPoints.Length - 1)
					nextWayPoint++;
				else
					nextWayPoint = 0;
			}
		}
	}

	void UpdateSight() {
		enemy.sight.material.color = Color.green;
	}
}
