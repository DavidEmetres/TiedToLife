using UnityEngine;
using System.Collections;

public class AlertState : IEnemy {

	EnemyBehaviour enemy;
	bool timeStarted = false;

	public float alertTime = 5f;
	public float timeCounter = 0f;

	public AlertState (EnemyBehaviour enemy) {
		this.enemy = enemy;
	}

	public void UpdateState () {
		UpdateSight ();

		if (!timeStarted) {
			timeCounter = alertTime;
			timeStarted = true;
		}
		else {
			Timer ();
		}
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
		//Not used
	}

	public void ToPatrolState() {
		enemy.currentState = enemy.patrolState;
		timeStarted = false;
		enemy.nav.Resume ();
	}

	public void ToAlertState() {
		//Cant change to same state
	}

	public void ToChaseState() {
		enemy.currentState = enemy.chaseState;
		enemy.sightAnim.SetTrigger ("Alerting");
		timeStarted = false;
		enemy.nav.Resume ();
	}

	void Timer() {
		if (timeCounter > 0f) {
			timeCounter -= Time.deltaTime;
		}
		else {
			enemy.sightAnim.SetTrigger ("Alerting");
			ToPatrolState ();
		}
	}

	void UpdateSight() {
		enemy.sight.material.color = new Color(1,1,0,0.25f);
	}
}
