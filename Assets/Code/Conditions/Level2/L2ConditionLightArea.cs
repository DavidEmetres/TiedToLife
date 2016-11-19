using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class L2ConditionLightArea : MonoBehaviour {

	[SerializeField] GameObject light;
	public List<GameObject> enemiesInArea = new List<GameObject>();
	public bool active = true;

	void Update () {
		Debug.Log ("ENEMIGOS EN LA LUZ: " + enemiesInArea.Count);
		if (active) {
			foreach (GameObject enemy in enemiesInArea) {
				enemy.GetComponentInParent<EnemyBehaviour> ().stunned = true;
			}

			light.SetActive (true);
		} 
		else {
			foreach (GameObject enemy in enemiesInArea) {
				enemy.GetComponentInParent<EnemyBehaviour> ().stunned = false;
			}

			light.SetActive (false);
		}

		if (StatePuppetBehavior.Instance.GetComponent<StatePuppetBehavior> ().currentState == StatePuppetBehavior.Instance.GetComponent<StatePuppetBehavior> ().stillState) {
			active = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.name + " ENTRO EN LA LUZ");
		if (other.tag == "Enemy") {
			enemiesInArea.Add (other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Enemy") {
			if (enemiesInArea.Contains (other.gameObject)) {
				enemiesInArea.Remove (other.gameObject);
			}
		}
	}
}
