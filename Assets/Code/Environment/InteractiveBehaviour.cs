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

	}

	public void Use() {
		this.gameObject.SendMessage ("UseObj");
	}
}
