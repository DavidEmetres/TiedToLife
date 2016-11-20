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

	public void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			ToChaseState ();
		}
	}

	public void OnTriggerExit(Collider other) {

	}

	public void ToPatrolState() {
		//Cant change to same state
	}

	public void ToAlertState() {
		enemy.currentState = enemy.alertState;
		enemy.sightAnim.SetTrigger ("Alerting");
	}

	public void ToChaseState() {
		enemy.currentState = enemy.chaseState;
	}

	void Patrol() {
		enemy.nav.Resume ();
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
		enemy.sight.material.color = new Color(0,1,0,0.25f);
	}
}
