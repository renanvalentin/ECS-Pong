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
}