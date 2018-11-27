using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Meta, Unique]
public class ObjectBoundServiceComponent : IComponent {
    public IBound instance;
}