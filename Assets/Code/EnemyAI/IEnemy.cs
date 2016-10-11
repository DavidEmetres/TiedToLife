using UnityEngine;
using System.Collections;

public interface IEnemy {

	void UpdateState ();
	void OnSightTriggerEnter(Collider other);
	void OnSightTriggerExit(Collider other);
	void OnNearZoneTriggerEnter(Collider other);
	void ToPatrolState();
	void ToAlertState();
	void ToChaseState();
}
