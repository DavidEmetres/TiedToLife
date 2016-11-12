using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {

	[SerializeField] Transform stringStart;
	[SerializeField] Transform[] stringsEnd;
	bool puppetClose = false;
	GameObject[] puppetStrings = new GameObject[3];

	void Start() {
		for (int i = 0; i < stringsEnd.Length; i++) {
			puppetStrings [i] = DrawLine (stringStart.position, stringsEnd [i].position, Color.white);
		}
	}

	void Update() {
		if (Input.GetButtonDown ("GrabButton")) {
			if (StatePuppetBehavior.Instance.isGrabbed)
				StatePuppetBehavior.Instance.GrabPuppet (false);
			else if (!StatePuppetBehavior.Instance.isGrabbed && puppetClose)
				StatePuppetBehavior.Instance.GrabPuppet (true);
		}

		if (StatePuppetBehavior.Instance.isGrabbed) {
			UpdateStrings ();
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "interactive") {
			if (Input.GetButtonDown ("ActionButton")) {
				other.gameObject.SendMessage ("Use");
			}
		}

		if (other.tag == "Puppet") {
				puppetClose = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Puppet") {
			puppetClose = false;
		}
	}

	void UpdateStrings() {
		for (int i = 0; i < puppetStrings.Length; i++) {
			puppetStrings [i].GetComponent<LineRenderer> ().SetPosition (0, stringStart.position);
			puppetStrings [i].GetComponent<LineRenderer> ().SetPosition (1, stringsEnd [i].position);
		}
	}

	GameObject DrawLine(Vector3 start, Vector3 end, Color color) {
		GameObject line = new GameObject ();
		line.transform.position = start;
		line.AddComponent<LineRenderer> ();
		line.transform.SetParent (this.transform);
		LineRenderer lr = line.GetComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
		lr.SetColors (color, color);
		lr.SetWidth (0.01f, 0.01f);
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
		return line;
	}
}
