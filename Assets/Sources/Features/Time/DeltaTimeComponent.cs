using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Meta, Unique]
public class DeltaTimeComponent : IComponent
{
    public float value;
}
