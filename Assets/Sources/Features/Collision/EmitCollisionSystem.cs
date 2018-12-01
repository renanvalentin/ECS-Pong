using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class EmitCollisionSystem : ReactiveSystem<GameEntity> {
    readonly IGroup<GameEntity> _rayCasts;
    private readonly MetaContext _meta;

    public EmitCollisionSystem (Contexts contexts) : base (contexts.game) {
        _rayCasts = contexts.game.GetGroup (GameMatcher.AnyOf (GameMatcher.RaycastCollision, GameMatcher.VerticalRaycastCollision));
        _meta = contexts.meta;

    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector (GameMatcher.AnyOf (GameMatcher.RaycastCollision, GameMatcher.VerticalRaycastCollision));
    }

    protected override bool Filter (GameEntity entity) {
        return entity.hasVelocity && entity.hasShellRadius;
    }

    protected override void Execute (List<GameEntity> entities) {
        foreach (var entity in entities) {
            if (entity.hasRaycastCollision) {
                RaycastCollisionComponent collision = entity.raycastCollision;
                if (HasCollided (collision, entity.shellRadius.value)) {
                    entity.ReplaceCollider (collision.other, collision.friction, collision.point, collision.normal);
                }
            }
        }
    }

    private bool HasCollided (RaycastCollisionComponent collision, float shell) {
        return (collision.friction - shell) < collision.rayLenth;
    }
}