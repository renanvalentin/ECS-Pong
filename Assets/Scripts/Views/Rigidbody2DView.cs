using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class Rigidbody2DView : View, IRigidbody {
    public ContactFilter2D contactFilter;

    private Rigidbody2D _rigidbody2D;

    private Raycast _raycast;

    public void Awake () {
        _rigidbody2D = GetComponent<Rigidbody2D> ();
    }

    public override void Link (IEntity entity, IContext context) {
        gameObject.Link (entity, context);
        var e = (GameEntity) entity;
        e.AddPositionListener (this);
        e.AddDestroyedListener (this);
        e.AddRigidBody (this);

        _entity = entity;

        var pos = e.position.value;

        _rigidbody2D.MovePosition (new Vector3 (pos.x, pos.y));
    }

    public ContactFilter2D Filter {
        get { return contactFilter; }
    }

    public int Cast (Vector2 direction, float distance, RaycastHit2D[] buffer, ContactFilter2D contactFilter2D) {
#if UNITY_EDITOR
        if (GameObject.Find ("GameController").GetComponent<GameController> ().debug) {
            Debug.DrawRay (_rigidbody2D.position, direction, Color.red, .1f);
        }
#endif

        return _rigidbody2D.Cast (direction, contactFilter2D, buffer, distance);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos () {
        GameEntity entity = (GameEntity) this.GetEntity ();

        if (entity != null && entity.hasRaycastRadius) {
            Gizmos.DrawWireSphere (entity.position.value, entity.raycastRadius.radius);

            Gizmos.DrawWireSphere (entity.position.value, entity.raycastRadius.radius);
            Vector2 viewAngleA = DirFromAngle (-entity.angle.value / 2, false);
            Vector2 viewAngleB = DirFromAngle (entity.angle.value / 2, false);

            float direction = Mathf.Sign (entity.direction.value);

            Gizmos.DrawLine (entity.position.value, entity.position.value + viewAngleA * entity.raycastRadius.radius * direction);
            Gizmos.DrawLine (entity.position.value, entity.position.value + viewAngleB * entity.raycastRadius.radius * direction);
        }
    }

    public Vector3 DirFromAngle (float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3 (Mathf.Sin (angleInDegrees * Mathf.Deg2Rad), Mathf.Cos (angleInDegrees * Mathf.Deg2Rad), 0);
    }
#endif

}