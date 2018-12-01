using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ColliderCleanupSystem : ICleanupSystem {

    readonly IGroup<GameEntity> _group;
    readonly List<GameEntity> _buffer = new List<GameEntity> ();

    public ColliderCleanupSystem (Contexts contexts) {
        _group = contexts.game.GetGroup (GameMatcher.RaycastCollision);
    }

    public void Cleanup () {
        foreach (var e in _group.GetEntities (_buffer)) {
            e.RemoveRaycastCollision ();
            e.isVerticalRaycastCollision = false;
            e.isHorizontalRaycastCollision = false;
        }
    }
}