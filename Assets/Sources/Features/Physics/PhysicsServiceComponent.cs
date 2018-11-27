using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Meta, Unique]
public class PhysicsServiceComponent : IComponent
{
    public IPhysics instance;
}
