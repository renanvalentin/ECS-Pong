using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Cleanup (CleanupMode.RemoveComponent)]
public class OverlapCircleCollisionComponent : IComponent {
    public IEntity other;
    public float radius;
}