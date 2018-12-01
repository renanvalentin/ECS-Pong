using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class EmitRaycastSystem : IExecuteSystem {
    private readonly MetaContext _meta;

    private IGroup<GameEntity> _group;

    private IPhysics _physicsService;

    public EmitRaycastSystem (Contexts contexts) {
        _group = contexts.game.GetGroup (GameMatcher.Raycast);
        _physicsService = contexts.meta.physicsService.instance;
    }

    public void Execute () {
        foreach (var entity in _group.GetEntities ()) {
            Vector2 velocity = entity.velocity.value;
            Vector2 horizontalDirection = Vector2.right * Mathf.Sign (velocity.x);
            Vector2 verticalDirection = Vector2.up * Mathf.Sign (velocity.y);
            float rayLength = velocity.magnitude;

            Cast (entity, horizontalDirection, rayLength, false);
            Cast (entity, verticalDirection, rayLength, true);
        }
    }

    private void Cast (GameEntity entity, Vector2 direction, float rayLength, bool vertical) {
        IRigidbody rigidBody = entity.rigidBody.Value;

        float shell = entity.shellRadius.value;

        List<RaycastHit2D> hitBufferList =
            _physicsService.RigidbodyCast (rigidBody, direction, rayLength + shell);

        for (int i = 0; i < hitBufferList.Count; i++) {
            Collider2D collider = hitBufferList[i].collider;
            IEntity other = collider.GetComponent<IView> ().GetEntity ();

            float distance = hitBufferList[i].distance;
            RaycastHit2D hit = hitBufferList[i];

            if (vertical) {
                entity.isVerticalRaycastCollision = true;
            } else {
                entity.isHorizontalRaycastCollision = true;
            }

            entity.ReplaceRaycastCollision (other, rayLength, distance, hit.point, hit.normal);
        }
    }
}