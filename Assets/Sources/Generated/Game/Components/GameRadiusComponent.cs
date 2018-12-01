//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RadiusComponent radius { get { return (RadiusComponent)GetComponent(GameComponentsLookup.Radius); } }
    public bool hasRadius { get { return HasComponent(GameComponentsLookup.Radius); } }

    public void AddRadius(float newValue) {
        var index = GameComponentsLookup.Radius;
        var component = CreateComponent<RadiusComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRadius(float newValue) {
        var index = GameComponentsLookup.Radius;
        var component = CreateComponent<RadiusComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRadius() {
        RemoveComponent(GameComponentsLookup.Radius);
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

    static Entitas.IMatcher<GameEntity> _matcherRadius;

    public static Entitas.IMatcher<GameEntity> Radius {
        get {
            if (_matcherRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Radius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRadius = matcher;
            }

            return _matcherRadius;
        }
    }
}
