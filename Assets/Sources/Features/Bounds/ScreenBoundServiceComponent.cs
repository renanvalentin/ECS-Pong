using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Meta, Unique]
public class ScreenBoundServiceComponent : IComponent
{
    public IBound instance;
}
