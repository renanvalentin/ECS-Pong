using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (Rigidbody2DView))]
public class FieldOfViewEditor : Editor {

	private void OnSceneGUI () {
		Rigidbody2DView view = (Rigidbody2DView) target;

		GameEntity entity = (GameEntity) view.GetComponent<IView> ().GetEntity ();

		float angle = entity.fieldOfView.angle;
		float radius = entity.fieldOfView.radius;

		Handles.color = Color.white;
		Handles.DrawWireArc (view.transform.position, Vector3.up, Vector3.forward, 360, radius);
		Vector3 viewAngleA = DirFromAngle (-angle / 2);
		Vector3 viewAngleB = DirFromAngle (angle / 2);

		float direction = Mathf.Sign (entity.direction.value);

		Handles.DrawLine (view.transform.position, view.transform.position + viewAngleA * radius * direction);
		Handles.DrawLine (view.transform.position, view.transform.position + viewAngleB * radius * direction);
	}

	private Vector3 DirFromAngle (float angleInDegrees) {
		return new Vector3 (Mathf.Sin (angleInDegrees * Mathf.Deg2Rad), Mathf.Cos (angleInDegrees * Mathf.Deg2Rad), 0);
	}

}