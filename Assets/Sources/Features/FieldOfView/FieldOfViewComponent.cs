using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class FieldOfViewComponent : IComponent {
    public float angle;
    public float radius;
}