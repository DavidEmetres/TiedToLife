using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

	[SerializeField] GameObject attachedObj;
	bool active = false;

	public void Use() {
		if (!active) {
			attachedObj.SendMessage ("Use");
			active = true;
		}
		else {
			attachedObj.SendMessage ("Use");
			active = false;
		}
	}
}
