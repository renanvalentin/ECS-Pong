//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ShellRadiusComponent shellRadius { get { return (ShellRadiusComponent)GetComponent(GameComponentsLookup.ShellRadius); } }
    public bool hasShellRadius { get { return HasComponent(GameComponentsLookup.ShellRadius); } }

    public void AddShellRadius(float newValue) {
        var index = GameComponentsLookup.ShellRadius;
        var component = CreateComponent<ShellRadiusComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceShellRadius(float newValue) {
        var index = GameComponentsLookup.ShellRadius;
        var component = CreateComponent<ShellRadiusComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveShellRadius() {
        RemoveComponent(GameComponentsLookup.ShellRadius);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherShellRadius;

    public static Entitas.IMatcher<GameEntity> ShellRadius {
        get {
            if (_matcherShellRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ShellRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShellRadius = matcher;
            }

            return _matcherShellRadius;
        }
    }
}
