﻿using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IView, IPositionListener, IDestroyedListener, IDirectionListener {
    protected IEntity _entity;

    public IEntity GetEntity () {
        return _entity;
    }

    public virtual void Link (IEntity entity, IContext context) {
        gameObject.Link (entity, context);
        var e = (GameEntity) entity;
        e.AddPositionListener (this);
        e.AddDestroyedListener (this);

        _entity = entity;

        var pos = e.position.value;
        transform.localPosition = new Vector3 (pos.x, pos.y);
        // transform.rotation = Quaternion.AngleAxis (e.direction.value - 90, Vector3.forward);
    }

    public virtual void OnPosition (GameEntity entity, Vector2 value) {
        transform.localPosition = new Vector3 (value.x, value.y);
    }

    public virtual void OnDirection (GameEntity entity, float value) {
        transform.rotation = Quaternion.AngleAxis (value - 90, Vector3.forward);

    }

    public virtual void OnDestroyed (GameEntity entity) {
        destroy ();
    }

    protected void destroy () {
        gameObject.Unlink ();
        Destroy (gameObject);
    }
}