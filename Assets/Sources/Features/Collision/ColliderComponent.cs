using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Cleanup(CleanupMode.RemoveComponent)]
public class ColliderComponent : IComponent
{
    public IEntity other;
    public float friction;
    public Vector2 point;
    public Vector2 normal;
}
