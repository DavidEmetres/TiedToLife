using UnityEngine;
using System.Collections;

public class ChaseState : IEnemy {

	EnemyBehaviour enemy;
	Vector3 lastPos;
	bool missing = false;

	public ChaseState (EnemyBehaviour enemy) {
		this.enemy = enemy;
	}

	public void UpdateState () {
		Chase ();
		UpdateSight ();

		if (enemy.occluded)
			missing = true;
	}

	public void OnSightTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if(!enemy.occluded)
				missing = false;
		}
	}

	public void OnSightTriggerExit(Collider other) {
		if (other.tag == "Player") {
			missing = true;
		}
	}

	public void OnNearZoneTriggerEnter(Collider other) {
		//Not used
	}

	public void ToPatrolState() {
		//Cant change to this state
	}

	public void ToAlertState() {
		enemy.currentState = enemy.alertState;
		enemy.sightAnim.SetTrigger ("Alerting");
	}

	public void ToChaseState() {
		//Cant change to same state
	}

	void Chase() {
		enemy.nav.Resume ();

		if (missing) {
			enemy.nav.SetDestination (lastPos);

			if (Vector3.Distance(enemy.transform.position, lastPos) < 1f) {
				ToAlertState ();
				missing = false;
			}
		}
		else if (enemy.target != null) {
			enemy.nav.SetDestination (enemy.target.position);
			lastPos = enemy.target.position;
		}
	}

	void UpdateSight() {
		enemy.sight.material.color = new Color(1,0,0,0.25f);
	}
}
