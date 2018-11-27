using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public enum ScreenCollision
{
    TOP,
    BOTTOM,
    LEFT,
    RIGHT
}

[Game]
public class ScreenBoundCollisionComponent : IComponent
{
    public ScreenCollision value;
}
