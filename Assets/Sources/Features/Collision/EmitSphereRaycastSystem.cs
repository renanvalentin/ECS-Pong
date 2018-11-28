using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class EmitSphereRaycastSystem : IExecuteSystem {
    private readonly MetaContext _meta;

    private IGroup<GameEntity> _group;

    private IPhysics _physicsService;

    private readonly RaycastHit2D[] _buffer = new RaycastHit2D[16];

    public EmitSphereRaycastSystem (Contexts contexts) {
        _group = contexts.game.GetGroup (GameMatcher.RaycastRadius);
        _physicsService = contexts.meta.physicsService.instance;
    }

    public void Execute () {
        foreach (var entity in _group.GetEntities ()) {
            int layerMask = 1 << LayerMask.NameToLayer (entity.collisionLayer.name);
            layerMask = ~layerMask;

            int hitCount = _physicsService.SphereCast (entity.position.value, entity.raycastRadius.radius, _buffer, layerMask);

            for (int i = 0; i < hitCount; i++) {
                RaycastHit2D hit = _buffer[i];
                Collider2D collider = hit.collider;

                IEntity other = collider.GetComponent<IView> ().GetEntity ();

                entity.ReplaceRaycastCollision (other, entity.raycastRadius.radius, hit.distance, hit.point, hit.normal);
            }
        }
    }

}