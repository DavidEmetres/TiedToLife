using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField] Camera mainCamera;
	CharacterController cController;
	GameObject playerModel;

	[Range (0.1f, 5f)] public float speed = 4f;

	void Start () {
		cController = GetComponent<CharacterController> ();
		playerModel = transform.GetChild (1).gameObject;

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
		HandleMovement ();
		HandleCamera ();
	}

	void HandleMovement() {
		Vector3 forward = mainCamera.transform.TransformDirection (Vector3.forward);
		forward.y = 0f;
		forward = forward.normalized;
		Vector3 right = new Vector3 (forward.z, 0f, -forward.x);

		float xMov = Input.GetAxis ("Horizontal");
		float yMov = Input.GetAxis ("Vertical");

		Vector3 movement = (xMov * right + yMov * forward);

		cController.SimpleMove (movement * speed);

		if (yMov != 0 || xMov != 0) {
			float lerpAngle = Mathf.LerpAngle (playerModel.transform.localEulerAngles.y, mainCamera.transform.localEulerAngles.y, Time.deltaTime * 5f);
			playerModel.transform.localEulerAngles = new Vector3 (playerModel.transform.localEulerAngles.x, lerpAngle, playerModel.transform.localEulerAngles.z);
		}
	}

	void HandleCamera() {
		float xRot = Input.GetAxis ("Mouse X");

		mainCamera.transform.RotateAround (this.transform.position, Vector3.up, 5f * xRot);
	}
}
