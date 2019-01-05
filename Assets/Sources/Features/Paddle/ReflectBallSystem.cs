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
        return entity.hasInput && entity.input.value == InputButton.Fire;
    }

    protected override void Execute (List<InputEntity> entities) {
        foreach (var entity in entities) {
            var ownerId = entity.inputOwner.playerId;
            var paddle = _contexts.game.GetEntityWithPlayer (ownerId);

            if (!paddle.hasOverlapCircleCollision || entity.input.value != InputButton.Fire) {
                continue;
            }

            GameEntity other = (GameEntity) paddle.overlapCircleCollision.other;

            Vector2 otherPosition = other.position.value;

            Vector2 velocity = other.velocity.value;
            float speed = velocity.magnitude;

            Vector2 ballPositon = other.position.value;
            Vector2 dirToTarget = (ballPositon - paddle.position.value).normalized;

            // Vector2 direction = new Vector3 (Mathf.Sin (paddle.direction.value * Mathf.Deg2Rad), Mathf.Cos (paddle.direction.value * Mathf.Deg2Rad), 0);
            Vector2 direction = paddle.direction.value > 0 ? Vector2.up : Vector2.down;

            float angle = Vector2.Angle (direction, dirToTarget);

            if (angle < paddle.fieldOfView.angle / 2) {
                float radius = paddle.overlapCircleCollision.radius;
                Vector2 reflectDir = otherPosition - paddle.position.value;
                Vector2 normal = new Vector2 (-reflectDir.y, reflectDir.x).normalized;
                float distance = reflectDir.magnitude;

                Vector2 nextVelocity = Vector2.Reflect (reflectDir.normalized, normal) * speed;
                other.ReplaceVelocity (nextVelocity);

                other.ReplaceOscillation (speed, angle, other.oscillation.time);

                float hitDistance = paddle.overlapCircleCollision.radius - distance;
                float maxspeed = other.maxSpeed.value;
                float currentspeed = other.speed.value;

                float nextSpeed = Mathf.Sin (((radius - distance) / radius) * (Mathf.PI / 2)) * maxspeed;

                float minSpeed = maxspeed * 0.25f;

                nextSpeed = Mathf.Clamp (nextSpeed * maxspeed, minSpeed, maxspeed * maxspeed);

                other.ReplaceSpeed (nextSpeed);
            }
        }
    }
}