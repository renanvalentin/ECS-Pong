using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class EmitOverlapCircleSystem : IExecuteSystem {
    private readonly MetaContext _meta;

    private IGroup<GameEntity> _group;

    private IPhysics _physicsService;

    private readonly Collider2D[] _buffer = new Collider2D[16];

    public EmitOverlapCircleSystem (Contexts contexts) {
        _group = contexts.game.GetGroup (GameMatcher.RaycastRadius);
        _physicsService = contexts.meta.physicsService.instance;
    }

    public void Execute () {
        foreach (var entity in _group.GetEntities ()) {
            int layerMask = 1 << LayerMask.NameToLayer (entity.collisionLayer.name);
            layerMask = ~layerMask;

            int hitCount = _physicsService.OverlapCircle (entity.position.value, entity.raycastRadius.radius, _buffer, layerMask);

            for (int i = 0; i < hitCount; i++) {
                Collider2D collider = _buffer[i];

                IEntity other = collider.GetComponent<IView> ().GetEntity ();

                entity.ReplaceOverlapCircleCollision (other, entity.raycastRadius.radius);
            }
        }
    }

}