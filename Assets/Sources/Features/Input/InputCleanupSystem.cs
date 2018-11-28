using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class InputCleanupSystem : ICleanupSystem {

    readonly IGroup<InputEntity> _group;
    readonly List<InputEntity> _buffer = new List<InputEntity> ();

    public InputCleanupSystem (Contexts contexts) {
        _group = contexts.input.GetGroup (InputMatcher.Input);
    }

    public void Cleanup () {
        foreach (var e in _group.GetEntities (_buffer)) {
            e.Destroy ();
        }
    }
}