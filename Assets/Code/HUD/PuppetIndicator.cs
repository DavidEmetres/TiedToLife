using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuppetIndicator : MonoBehaviour {

	Vector3 puppetViewport;
	float maxX;
	float maxY;

	void Start () {
		maxX = 1920 / 2 - 50;
		maxY = 1080 / 2 - 50;
	}
	
	void Update () {
		puppetViewport = Camera.main.WorldToViewportPoint (StatePuppetBehavior.Instance.transform.position);

		if (puppetViewport.x > 1 || puppetViewport.x < 0 || puppetViewport.y > 1 || puppetViewport.y < 0) {
			GetComponent<Image> ().enabled = true;
			AimPuppet ();
		}

		else
			GetComponent<Image> ().enabled = false;

//		AimPuppet ();
	}

	void AimPuppet() {
		Vector3 puppetScreenPoint = Camera.main.WorldToScreenPoint (StatePuppetBehavior.Instance.transform.position);
		Vector3 arrowScreenPoint = new Vector3(Camera.main.pixelWidth/2, Camera.main.pixelHeight/2, 0f);

		Vector3 direction = puppetScreenPoint - arrowScreenPoint;
		direction.Normalize ();

		transform.up = direction;
		transform.localEulerAngles = new Vector3 (0f, 0f, transform.localEulerAngles.z);

		float pvx = puppetViewport.x;
		pvx = (pvx > 0.97f) ? 0.97f : pvx;
		pvx = (pvx < 0.03f) ? 0.03f : pvx;

		float pvy = puppetViewport.y;
		pvy = (pvy > 0.95f) ? 0.95f : pvy;
		pvy = (pvy < 0.05f) ? 0.05f : pvy;

		Vector3 screenPos = new Vector3 (pvx * 1920, pvy * 1080, 0f);

		transform.localPosition = new Vector3(screenPos.x - 960, screenPos.y - 540, 0f);
	}
}
