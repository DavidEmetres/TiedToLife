using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {

	[SerializeField] Transform stringStart;
	[SerializeField] Transform[] stringsEnd;
	bool puppetClose = false;
	GameObject[] puppetStrings = new GameObject[3];

	public int numStringPoint = 9;
	public float maxDephtPoint = 1f;

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
			SetStringsVisible (true);
			UpdateStrings ();
		}
		else
			SetStringsVisible (false);
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

	void SetStringsVisible(bool b) {
		foreach (GameObject s in puppetStrings) {
			s.SetActive (b);
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
		line.transform.SetParent (this.transform.GetChild(3).transform);
		LineRenderer lr = line.GetComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
		lr.SetColors (color, color);
		lr.SetWidth (0.01f, 0.01f);
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
		return line;
	}

	/*GameObject DrawLine(Vector3 start, Vector3 end, Color color) {
		GameObject line = new GameObject ();
		line.transform.position = start;
		line.AddComponent<LineRenderer> ();
		line.transform.SetParent (this.transform.GetChild(3).transform);
		LineRenderer lr = line.GetComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
		lr.SetColors (color, color);
		lr.SetWidth (0.01f, 0.01f);

		Vector3[] points = new Vector3[numStringPoint];
		points [0] = start;
		points [numStringPoint-1] = end;

		float distX = end.x - start.x;
		float distZ = end.z - start.z;
		float sepX = distX / numStringPoint;
		float sepZ = distZ / numStringPoint;
		Vector2 vert = GetParaboleVertex (start, end);

		float sepY = vert.y / (numStringPoint/2);
		//float maxY = (start.y > end.y) ? start.y : end.y;*/

		/*for (int i = 1; i <= (numStringPoint-2); i++) {
			points [i] = new Vector3 (points[i-1].x + sepX, start.y, points[i-1].z + sepZ);
		}*/

		/*for (int i = 1; i <= (numStringPoint/2); i++) {
			Vector2 res = GetParabolePoint (points [0].y + (sepY * i), vert);
			points [i] = new Vector3 (points [0].x + (sepX * i), points [0].y + (sepY * i), res.x);
			points [(numStringPoint-1) - i] = new Vector3 (points [0].x + (sepX * ((numStringPoint-1) - i)), points [0].y + (sepY * i), res.x);
		}

		lr.SetVertexCount (numStringPoint);

		for (int i = 0; i < points.Length; i++) {
			lr.SetPosition (i, points [i]);
		}

		return line;
	}

	Vector2 GetParaboleVertex(Vector3 start, Vector3 end) {
		float sx = start.z;
		float sy = start.y;
		float ex = end.z;
		float ey = end.y;

		float a = ((2 * Mathf.PI * sy) - (Mathf.Pow(sx, 2)) + (Mathf.Pow(ex, 2)) - (2 * Mathf.PI * ey))/((2 * sx) - (2 * ex));
		float b = ((Mathf.Pow (a, 2)) + (2 * ex * a) + (Mathf.Pow (ex, 2)) - (2 * Mathf.PI * ey)) / (2 * Mathf.PI);

		Vector2 res = new Vector2 (a, b);
		return res;
	}

	Vector2 GetParabolePoint(float y, Vector2 vert) {
		float a = 1;
		float b = 2 * vert.x;
		float c = (Mathf.Pow (vert.x, 2) - (2 * Mathf.PI * y) + (2 * Mathf.PI * vert.y));
		float rx1 = ((-b) + (Mathf.Sqrt (Mathf.Pow (b, 2) - 4 * a * c))) / (2 * a);
		float rx2 = ((-b) - (Mathf.Sqrt (Mathf.Pow (b, 2) - 4 * a * c))) / (2 * a);

		Vector2 res = new Vector2 (rx1, rx2);
		return res;
	}*/
}
