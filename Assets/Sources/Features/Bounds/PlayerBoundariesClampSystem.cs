using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class PlayerBoundariesClampSystem : ReactiveSystem<GameEntity> {
    public PlayerBoundariesClampSystem (Contexts contexts) : base (contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector (GameMatcher.Position);
    }

    protected override bool Filter (GameEntity entity) {
        return entity.hasPlayer && entity.hasBound;
    }

    protected override void Execute (List<GameEntity> entities) {
        foreach (var entity in entities) {
            Vector2 position = entity.position.value;
            Vector2 minBound = entity.bound.min;
            Vector2 maxBound = entity.bound.max;

            if (!(position.x >= minBound.x && position.x <= maxBound.x)) {
                position.x = Mathf.Clamp (position.x, minBound.x, maxBound.x);
            } else if (!(position.y >= minBound.y && position.y <= maxBound.y)) {

                position.y = Mathf.Clamp (position.y, minBound.y, maxBound.y);
            }

            entity.ReplacePosition (position);
        }
    }
}