using UnityEngine;
using System.Collections;

public class AlertState : IEnemy {

	EnemyBehaviour enemy;

	public float alertTime = 5f;

	public AlertState (EnemyBehaviour enemy) {
		this.enemy = enemy;
	}

	public void UpdateState () {

	}

	public void OnTriggerEnter(Collider other) {

	}

	public void ToPatrolState() {

	}

	public void ToAlertState() {

	}

	public void ToChaseState() {

	}
}
