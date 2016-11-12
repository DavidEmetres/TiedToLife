using UnityEngine;
using System.Collections;

public class RopeBehaviour : MonoBehaviour {

	void Update () {
		transform.position = StatePuppetBehavior.Instance.transform.position;
	}
}
