//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PlayerScreenPositionComponent playerScreenPosition { get { return (PlayerScreenPositionComponent)GetComponent(GameComponentsLookup.PlayerScreenPosition); } }
    public bool hasPlayerScreenPosition { get { return HasComponent(GameComponentsLookup.PlayerScreenPosition); } }

    public void AddPlayerScreenPosition(PlayerScreenPosition newValue) {
        var index = GameComponentsLookup.PlayerScreenPosition;
        var component = CreateComponent<PlayerScreenPositionComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerScreenPosition(PlayerScreenPosition newValue) {
        var index = GameComponentsLookup.PlayerScreenPosition;
        var component = CreateComponent<PlayerScreenPositionComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerScreenPosition() {
        RemoveComponent(GameComponentsLookup.PlayerScreenPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayerScreenPosition;

    public static Entitas.IMatcher<GameEntity> PlayerScreenPosition {
        get {
            if (_matcherPlayerScreenPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerScreenPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerScreenPosition = matcher;
            }

            return _matcherPlayerScreenPosition;
        }
    }
}
