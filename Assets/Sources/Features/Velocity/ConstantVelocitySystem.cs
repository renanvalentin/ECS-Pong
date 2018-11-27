using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ConstantVelocity : ReactiveSystem<GameEntity> {
    IGroup<GameEntity> _group;

    public ConstantVelocity (Contexts contexts) : base (contexts.game) {
        _group = contexts.game.GetGroup (GameMatcher.Velocity);
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector (GameMatcher.AllOf (GameMatcher.Velocity, GameMatcher.ConstantVelocity));
    }

    protected override bool Filter (GameEntity entity) {
        return entity.hasConstantVelocity;
    }

    protected override void Execute (List<GameEntity> entities) {
        foreach (var entity in entities) {
            entity.ReplaceVelocity (entity.constantVelocity.value.magnitude * entity.velocity.value.normalized);
        }
    }
}