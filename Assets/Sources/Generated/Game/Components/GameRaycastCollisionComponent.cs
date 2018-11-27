//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RaycastCollisionComponent raycastCollision { get { return (RaycastCollisionComponent)GetComponent(GameComponentsLookup.RaycastCollision); } }
    public bool hasRaycastCollision { get { return HasComponent(GameComponentsLookup.RaycastCollision); } }

    public void AddRaycastCollision(Entitas.IEntity newOther, float newRayLenth, float newFriction, UnityEngine.Vector2 newPoint, UnityEngine.Vector2 newNormal) {
        var index = GameComponentsLookup.RaycastCollision;
        var component = CreateComponent<RaycastCollisionComponent>(index);
        component.other = newOther;
        component.rayLenth = newRayLenth;
        component.friction = newFriction;
        component.point = newPoint;
        component.normal = newNormal;
        AddComponent(index, component);
    }

    public void ReplaceRaycastCollision(Entitas.IEntity newOther, float newRayLenth, float newFriction, UnityEngine.Vector2 newPoint, UnityEngine.Vector2 newNormal) {
        var index = GameComponentsLookup.RaycastCollision;
        var component = CreateComponent<RaycastCollisionComponent>(index);
        component.other = newOther;
        component.rayLenth = newRayLenth;
        component.friction = newFriction;
        component.point = newPoint;
        component.normal = newNormal;
        ReplaceComponent(index, component);
    }

    public void RemoveRaycastCollision() {
        RemoveComponent(GameComponentsLookup.RaycastCollision);
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

    static Entitas.IMatcher<GameEntity> _matcherRaycastCollision;

    public static Entitas.IMatcher<GameEntity> RaycastCollision {
        get {
            if (_matcherRaycastCollision == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RaycastCollision);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRaycastCollision = matcher;
            }

            return _matcherRaycastCollision;
        }
    }
}
