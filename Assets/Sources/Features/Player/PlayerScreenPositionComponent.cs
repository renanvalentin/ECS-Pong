using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public sealed class PlayerScreenPositionComponent : IComponent {
    public PlayerScreenPosition value;
}

public enum PlayerScreenPosition {
    Top,
    Bottom,
}