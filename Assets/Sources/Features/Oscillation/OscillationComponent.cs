using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class Oscillation : IComponent {
    public float frequency;
    public float amplitude;
    public float time;
}