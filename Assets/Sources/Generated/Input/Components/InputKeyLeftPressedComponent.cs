//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly KeyLeftPressedComponent keyLeftPressedComponent = new KeyLeftPressedComponent();

    public bool isKeyLeftPressed {
        get { return HasComponent(InputComponentsLookup.KeyLeftPressed); }
        set {
            if (value != isKeyLeftPressed) {
                var index = InputComponentsLookup.KeyLeftPressed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : keyLeftPressedComponent;

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

    static Entitas.IMatcher<InputEntity> _matcherKeyLeftPressed;

    public static Entitas.IMatcher<InputEntity> KeyLeftPressed {
        get {
            if (_matcherKeyLeftPressed == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.KeyLeftPressed);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherKeyLeftPressed = matcher;
            }

            return _matcherKeyLeftPressed;
        }
    }
}