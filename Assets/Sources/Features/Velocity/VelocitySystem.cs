using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public sealed class VelocitySystem : IExecuteSystem {
    private readonly MetaContext _meta;

    IGroup<GameEntity> _group;

    public VelocitySystem (Contexts contexts) {
        _group = contexts.game.GetGroup (GameMatcher.AllOf (GameMatcher.Velocity, GameMatcher.Speed));
        _meta = contexts.meta;
    }

    public void Execute () {
        foreach (var entity in _group.GetEntities ()) {
            if (_meta.deltaTime.value == 0) {
                Debug.LogFormat ("delta: {0}", _meta.deltaTime.value);
                continue;
            }

            // float speed = entity.velocity.value.magnitude;
            Vector2 frameVelocity = entity.velocity.value * entity.speed.value * _meta.deltaTime.value;
            //            entity.ReplacePosition(entity.position.value + nextVelocity);

            entity.ReplaceVelocity (frameVelocity);
        }
    }
}