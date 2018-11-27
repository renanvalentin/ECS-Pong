using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class BoundComponent : IComponent {
    public Vector2 min;
    public Vector2 max;
}