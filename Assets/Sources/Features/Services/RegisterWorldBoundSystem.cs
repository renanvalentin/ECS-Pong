using Entitas;

public class RegisterWorldBoundSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IBound _worldBound;

    public RegisterWorldBoundSystem(Contexts contexts, IBound worldBound)
    {
        _metaContext = contexts.meta;
        _worldBound = worldBound;
    }

    public void Initialize()
    {
        _metaContext.ReplaceWorldBoundService(_worldBound);
    }
}