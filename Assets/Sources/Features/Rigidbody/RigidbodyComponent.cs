using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class RigidBodyComponent : IComponent
{
    public IRigidbody Value;
}
