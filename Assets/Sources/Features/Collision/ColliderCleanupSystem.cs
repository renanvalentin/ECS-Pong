using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class CollisionCleanupSystem : ICleanupSystem {

    readonly IGroup<GameEntity> _group;
    readonly List<GameEntity> _buffer = new List<GameEntity>();

    public CollisionCleanupSystem(Contexts contexts) {
        _group = contexts.game.GetGroup(GameMatcher.Collider);
    }

    public void Cleanup() {
        foreach (var e in _group.GetEntities(_buffer)) {
            e.RemoveCollider();
        }
    }
}