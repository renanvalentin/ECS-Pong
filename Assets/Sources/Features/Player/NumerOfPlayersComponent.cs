using Entitas;
using Entitas.CodeGeneration.Attributes;

[Meta]
[Unique]
public sealed class NumberOfPlayersComponent : IComponent {
    public int total;
}