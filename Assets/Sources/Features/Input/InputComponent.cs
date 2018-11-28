using Entitas;

[Input]
public class InputComponent : IComponent {
    public InputButton value;
}

public enum InputButton {
    Left,
    Right,
    Up,
    Down,
    Fire
}