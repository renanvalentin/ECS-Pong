using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ReflectBallSystem : ReactiveSystem<InputEntity> {
    private Contexts _contexts;

    public ReflectBallSystem (Contexts contexts) : base (contexts.input) {
        _contexts = contexts;
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context) {
        return context.CreateCollector (InputMatcher.Input);
    }

    protected override bool Filter (InputEntity entity) {
        return entity.hasInput;
    }

    protected override void Execute (List<InputEntity> entities) {
        foreach (var entity in entities) {
            var ownerId = entity.inputOwner.playerId;
            var paddle = _contexts.game.GetEntityWithPlayer (ownerId);

            if (!paddle.hasRaycastCollision) {
                continue;
            }

            GameEntity other = (GameEntity) paddle.raycastCollision.other;
            Vector2 otherPosition = other.position.value;

            Vector2 velocity = other.velocity.value;
            float speed = velocity.magnitude;

            Vector2 positon = other.position.value;

            Vector2 nextVelocity = Vector2.Reflect ((paddle.raycastCollision.point - positon).normalized, paddle.raycastCollision.normal);

            // entity.ReplaceVelocity (nextVelocity * speed);
            other.ReplaceVelocity (nextVelocity * speed);

        }
    }
}