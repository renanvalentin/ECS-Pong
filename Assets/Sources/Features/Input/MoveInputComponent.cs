using Entitas;
using UnityEngine;

[Input]
public sealed class MoveInputComponent : IComponent {
    public Vector2 direction;
}