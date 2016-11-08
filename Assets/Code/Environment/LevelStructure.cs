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
}
