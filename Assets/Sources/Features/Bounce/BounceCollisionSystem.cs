using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Entitas;
using UnityEngine;

public sealed class BounceCollisionSystem : ReactiveSystem<GameEntity>, ICleanupSystem {
    readonly IGroup<GameEntity> _rayCasts;
    private readonly MetaContext _meta;

    public BounceCollisionSystem (Contexts contexts) : base (contexts.game) {
        _rayCasts = contexts.game.GetGroup (GameMatcher.Collider);
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector (GameMatcher.Collider);
    }

    protected override bool Filter (GameEntity entity) {
        return entity.isBounce && entity.hasVelocity && entity.hasShellRadius && entity.hasCollider;
    }

    protected override void Execute (List<GameEntity> entities) {
        foreach (var entity in entities) {
            Vector2 velocity = entity.velocity.value;
            float speed = velocity.magnitude;
            Vector2 positon = entity.position.value;

            GameEntity other = (GameEntity) entity.collider.other;
            Vector2 otherPosition = other.position.value;

            Vector2 nextVelocity = Vector2.Reflect ((entity.collider.point - positon).normalized, entity.collider.normal);

            entity.ReplaceVelocity (nextVelocity * speed);
        }
    }

    public void Cleanup () {
        foreach (var e in _rayCasts.GetEntities ()) {
            // e.RemoveCollider ();
        }
    }
}