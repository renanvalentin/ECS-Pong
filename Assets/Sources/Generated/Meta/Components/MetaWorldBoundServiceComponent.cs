//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity worldBoundServiceEntity { get { return GetGroup(MetaMatcher.WorldBoundService).GetSingleEntity(); } }
    public WorldBoundServiceComponent worldBoundService { get { return worldBoundServiceEntity.worldBoundService; } }
    public bool hasWorldBoundService { get { return worldBoundServiceEntity != null; } }

    public MetaEntity SetWorldBoundService(IBound newInstance) {
        if (hasWorldBoundService) {
            throw new Entitas.EntitasException("Could not set WorldBoundService!\n" + this + " already has an entity with WorldBoundServiceComponent!",
                "You should check if the context already has a worldBoundServiceEntity before setting it or use context.ReplaceWorldBoundService().");
        }
        var entity = CreateEntity();
        entity.AddWorldBoundService(newInstance);
        return entity;
    }

    public void ReplaceWorldBoundService(IBound newInstance) {
        var entity = worldBoundServiceEntity;
        if (entity == null) {
            entity = SetWorldBoundService(newInstance);
        } else {
            entity.ReplaceWorldBoundService(newInstance);
        }
    }

    public void RemoveWorldBoundService() {
        worldBoundServiceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity {

    public WorldBoundServiceComponent worldBoundService { get { return (WorldBoundServiceComponent)GetComponent(MetaComponentsLookup.WorldBoundService); } }
    public bool hasWorldBoundService { get { return HasComponent(MetaComponentsLookup.WorldBoundService); } }

    public void AddWorldBoundService(IBound newInstance) {
        var index = MetaComponentsLookup.WorldBoundService;
        var component = CreateComponent<WorldBoundServiceComponent>(index);
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceWorldBoundService(IBound newInstance) {
        var index = MetaComponentsLookup.WorldBoundService;
        var component = CreateComponent<WorldBoundServiceComponent>(index);
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveWorldBoundService() {
        RemoveComponent(MetaComponentsLookup.WorldBoundService);
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
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherWorldBoundService;

    public static Entitas.IMatcher<MetaEntity> WorldBoundService {
        get {
            if (_matcherWorldBoundService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.WorldBoundService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherWorldBoundService = matcher;
            }

            return _matcherWorldBoundService;
        }
    }
}