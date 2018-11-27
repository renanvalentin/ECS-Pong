//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly VerticalRaycastCollisionComponent verticalRaycastCollisionComponent = new VerticalRaycastCollisionComponent();

    public bool isVerticalRaycastCollision {
        get { return HasComponent(GameComponentsLookup.VerticalRaycastCollision); }
        set {
            if (value != isVerticalRaycastCollision) {
                var index = GameComponentsLookup.VerticalRaycastCollision;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : verticalRaycastCollisionComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherVerticalRaycastCollision;

    public static Entitas.IMatcher<GameEntity> VerticalRaycastCollision {
        get {
            if (_matcherVerticalRaycastCollision == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VerticalRaycastCollision);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVerticalRaycastCollision = matcher;
            }

            return _matcherVerticalRaycastCollision;
        }
    }
}