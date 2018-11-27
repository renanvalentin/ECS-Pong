using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Meta, Unique]
public class WorldBoundServiceComponent : IComponent
{
    public IBound instance;
}
