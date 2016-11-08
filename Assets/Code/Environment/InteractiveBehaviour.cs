using UnityEngine;
using System.Collections;

public class InteractiveBehaviour : MonoBehaviour {

	public int type;			//1: LEVER; 2: BUTTON
	public int defaultState;	//0: READY; 1: WAITTING FOR SOMETHING TO HAPPEN; -1: ALREADY USED
	public int currentState;

	void Start() {
		currentState = defaultState;
	}

	void Update() {
		if (this.gameObject.name == "Lever") {
			Debug.Log ("LEVER1 STATE: " + currentState + ", PRIORIDAD: " + LevelStructure.Instance.GetPriority(this.gameObject));
		}
	}

	public void Use() {
		this.gameObject.SendMessage ("UseObj");
	}
}
