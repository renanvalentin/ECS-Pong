using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class OverlapCircleCleanupSystem : ICleanupSystem {

    readonly IGroup<GameEntity> _group;
    readonly List<GameEntity> _buffer = new List<GameEntity> ();

    public OverlapCircleCleanupSystem (Contexts contexts) {
        _group = contexts.game.GetGroup (GameMatcher.OverlapCircleCollision);
    }

    public void Cleanup () {
        foreach (var e in _group.GetEntities (_buffer)) {
            e.RemoveOverlapCircleCollision ();
        }
    }
}