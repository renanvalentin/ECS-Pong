//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly KeyRightPressedComponent keyRightPressedComponent = new KeyRightPressedComponent();

    public bool isKeyRightPressed {
        get { return HasComponent(InputComponentsLookup.KeyRightPressed); }
        set {
            if (value != isKeyRightPressed) {
                var index = InputComponentsLookup.KeyRightPressed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : keyRightPressedComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherKeyRightPressed;

    public static Entitas.IMatcher<InputEntity> KeyRightPressed {
        get {
            if (_matcherKeyRightPressed == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.KeyRightPressed);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherKeyRightPressed = matcher;
            }

            return _matcherKeyRightPressed;
        }
    }
}
