//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RaycastRadiusComponent raycastRadius { get { return (RaycastRadiusComponent)GetComponent(GameComponentsLookup.RaycastRadius); } }
    public bool hasRaycastRadius { get { return HasComponent(GameComponentsLookup.RaycastRadius); } }

    public void AddRaycastRadius(float newRadius) {
        var index = GameComponentsLookup.RaycastRadius;
        var component = CreateComponent<RaycastRadiusComponent>(index);
        component.radius = newRadius;
        AddComponent(index, component);
    }

    public void ReplaceRaycastRadius(float newRadius) {
        var index = GameComponentsLookup.RaycastRadius;
        var component = CreateComponent<RaycastRadiusComponent>(index);
        component.radius = newRadius;
        ReplaceComponent(index, component);
    }

    public void RemoveRaycastRadius() {
        RemoveComponent(GameComponentsLookup.RaycastRadius);
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

    static Entitas.IMatcher<GameEntity> _matcherRaycastRadius;

    public static Entitas.IMatcher<GameEntity> RaycastRadius {
        get {
            if (_matcherRaycastRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RaycastRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRaycastRadius = matcher;
            }

            return _matcherRaycastRadius;
        }
    }
}