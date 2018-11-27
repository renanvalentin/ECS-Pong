using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public sealed class InputSystem : IExecuteSystem, ICleanupSystem {
    IGroup<InputEntity> _group;
    Contexts _contexts;

    public InputSystem (Contexts contexts) {
        _contexts = contexts;
        _group = contexts.input.GetGroup (InputMatcher.InputAxis);
    }

    public void Execute () {
        foreach (var entity in _group.GetEntities ()) {
            var e = _contexts.input.CreateEntity ();

            e.AddMoveInput (entity.inputAxis.axis);
            e.AddInputOwner (entity.inputOwner.playerId);
        }
    }

    public void Cleanup () {
        foreach (var e in _group.GetEntities ()) {
            e.Destroy ();
        }
    }
}