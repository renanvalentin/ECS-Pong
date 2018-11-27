using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class WorldBounceSystem : ReactiveSystem<GameEntity> {
    IBound _worldBound;

    public WorldBounceSystem (Contexts contexts) : base (contexts.game) {
        _worldBound = contexts.meta.worldBoundService.instance;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector (GameMatcher.Position);
    }

    protected override bool Filter (GameEntity entity) {
        return entity.isBounce;
    }

    protected override void Execute (List<GameEntity> entities) {
        foreach (var entity in entities) {
            Vector2 position = entity.position.value;
            float x = entity.velocity.value.x;
            float y = entity.velocity.value.y;

            if (position.x <= 0 || position.x >= _worldBound.Width) {
                x = x * -1;
            }

            if (position.y <= 0 || position.y >= _worldBound.Height) {
                y = y * -1;
            }

            entity.ReplaceVelocity (new Vector2 (x, y));
        }
    }
}