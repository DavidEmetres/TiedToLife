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

	public void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			ToChaseState ();
		}
	}

	public void OnTriggerExit(Collider other) {

	}

	public void ToPatrolState() {
		enemy.currentState = enemy.patrolState;
		timeStarted = false;
	}

	public void ToAlertState() {
		//Cant change to same state
	}

	public void ToChaseState() {
		Quaternion localRot;
		enemy.currentState = enemy.chaseState;
		enemy.sightAnim.SetTrigger ("Alerting");
		timeStarted = false;
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
		enemy.sight.material.color = Color.yellow;
	}
}
