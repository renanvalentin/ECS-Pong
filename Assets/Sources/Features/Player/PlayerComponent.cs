using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class PlayerComponent : IComponent {
    [PrimaryEntityIndex]
    public string id;
}