using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class OscillationSystem : ReactiveSystem<GameEntity> {
    IGroup<GameEntity> _group;
    private readonly MetaContext _meta;

    public OscillationSystem (Contexts contexts) : base (contexts.game) {
        _group = contexts.game.GetGroup (GameMatcher.Velocity);
        _meta = contexts.meta;
    }

    protected override ICollector<GameEntity> GetTrigger (IContext<GameEntity> context) {
        return context.CreateCollector (GameMatcher.Velocity);
    }

    protected override bool Filter (GameEntity entity) {
        return entity.hasOscillation;
    }

    protected override void Execute (List<GameEntity> entities) {
        foreach (var entity in entities) {
            Vector2 velocity = entity.velocity.value;
            float speed = velocity.magnitude;
            Vector2 forward = velocity.normalized;

            float time = entity.oscillation.time + _meta.deltaTime.value;
            float amplitude = entity.oscillation.amplitude;
            float frequency = entity.oscillation.frequency;
            // float speed = entity.speed.value;

            Vector2 up = new Vector2 (-forward.y, forward.x);
            float up_speed = Mathf.Cos (time * frequency) * amplitude * frequency * _meta.deltaTime.value;

            entity.ReplaceVelocity (up * up_speed + forward * speed);
            entity.ReplaceOscillation (frequency, amplitude, time);
        }
    }
}