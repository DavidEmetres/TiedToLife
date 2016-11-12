using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField] Camera mainCamera;
	CharacterController cController;
	GameObject playerModel;

	[Range (0.1f, 5f)] public float speed = 4f;
	[Range (1f, 10f)] public float mouseSensibility = 5f;

	public static PlayerController Instance;

	void Awake() {
		Instance = this;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Start () {
		cController = GetComponent<CharacterController> ();
		playerModel = transform.GetChild (1).gameObject;
		mainCamera.transform.RotateAround (this.transform.position, Vector3.up, -140f);
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

		float diagonallySpeedFactor = (xMov != 0.0f && yMov != 0.0f) ? 0.7071f : 1.0f;

		Vector3 movement = (xMov * diagonallySpeedFactor * right + yMov * diagonallySpeedFactor * forward);

		cController.SimpleMove (movement * speed);

		if (yMov != 0 || xMov != 0) {
			Quaternion newRotation = Quaternion.LookRotation (movement);
			playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, newRotation, Time.deltaTime * 5f);
		}
	}

	void HandleCamera() {
		float xRot = Input.GetAxis ("Mouse X");

		mainCamera.transform.RotateAround (this.transform.position, Vector3.up, mouseSensibility * xRot);
	}
}
