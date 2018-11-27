using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Cleanup(CleanupMode.RemoveComponent)]
public class HorizontalRaycastCollisionComponent : IComponent
{
}
