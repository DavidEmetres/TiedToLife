using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

	void Update () {
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.AddComponent<Rigidbody>();
		cube.AddComponent<BoxCollider> ();
		cube.transform.position = Vector3.zero;
	}
}
