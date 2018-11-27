using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ProcessMoveInputSystem : ReactiveSystem<InputEntity>, ICleanupSystem {
    private Contexts _contexts;
    IGroup<InputEntity> _group;

    public ProcessMoveInputSystem (Contexts contexts) : base (contexts.input) {
        _contexts = contexts;
        _group = contexts.input.GetGroup (InputMatcher.MoveInput);
    }

    protected override ICollector<InputEntity> GetTrigger (IContext<InputEntity> context) {
        return context.CreateCollector (InputMatcher.MoveInput);
    }

    protected override bool Filter (InputEntity entity) {
        return entity.hasMoveInput;
    }

    protected override void Execute (List<InputEntity> entities) {
        foreach (var entity in entities) {
            var ownerId = entity.inputOwner.playerId;

            var e = _contexts.game.GetEntityWithPlayer (ownerId);

            e.ReplaceVelocity (entity.moveInput.direction.normalized * 0.3f);

        }
    }

    public void Cleanup () {
        foreach (var e in _group.GetEntities ()) {
            e.Destroy ();
        }
    }
}