using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bla : MonoBehaviour {
	public Transform a;
	public Transform b;

	public float viewRadius;
	[Range (0, 360)]
	public float viewAngle;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var distanceAnB = b.position - a.position;

		Debug.DrawLine (a.position, b.position);
		Debug.DrawLine (a.position, Vector2.right, Color.red);

		float angle = Vector3.Dot (distanceAnB, Vector2.right);
		float degree = Mathf.Acos (angle) * Mathf.Rad2Deg;
		angle = Mathf.Abs (Mathf.Atan2 (distanceAnB.y, distanceAnB.x) * Mathf.Rad2Deg); //get angle

		Debug.Log ("angle: " + angle);
		// Debug.Log ("degree: " + degree);
	}

	public Vector3 DirFromAngle (float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal) {
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3 (Mathf.Sin (angleInDegrees * Mathf.Deg2Rad), Mathf.Cos (angleInDegrees * Mathf.Deg2Rad), 0);
	}

	#if UNITY_EDITOR
	private void OnDrawGizmos () {
		Gizmos.DrawWireSphere (a.transform.position, viewRadius);
		Vector3 viewAngleA = DirFromAngle (-viewAngle / 2, false);
		Vector3 viewAngleB = DirFromAngle (viewAngle / 2, false);

		Gizmos.DrawLine (a.transform.position, a.transform.position + viewAngleA * viewRadius);
		Gizmos.DrawLine (a.transform.position, a.transform.position + viewAngleB * viewRadius);
	}

	#endif

}