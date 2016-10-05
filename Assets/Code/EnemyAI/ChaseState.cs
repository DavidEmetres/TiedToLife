using UnityEngine;
using System.Collections;

public class ChaseState : IEnemy {

	EnemyBehaviour enemy;

	public ChaseState (EnemyBehaviour enemy) {
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
