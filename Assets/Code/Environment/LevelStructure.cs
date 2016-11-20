using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelStructure : MonoBehaviour {

	[SerializeField] List<GameObject> objOrder = new List<GameObject>();
	[SerializeField] List<GameObject> enemiesInLevel = new List<GameObject>();

	public static LevelStructure Instance;

	void Start () {
		Instance = this;
	}
	
	void Update () {

	}

	public int GetPriority(GameObject obj) {
		return objOrder.IndexOf (obj);
	}

	public void NextStep() {
		objOrder.RemoveAt (0);
	}

	public List<GameObject> GetEnemiesInLevel() {
		return enemiesInLevel;
	}

	public void AddNextAction(GameObject obj) {
		List<GameObject> temp = new List<GameObject>();

		foreach (GameObject o in objOrder) {
			temp.Add (o);
		}

		objOrder.Clear ();
		objOrder.Add (obj);

		foreach (GameObject o in temp) {
			objOrder.Add (o);
		}
	}
}
