using Entitas;

public class RegisterObjectBoundSystem : IInitializeSystem {
    private readonly MetaContext _metaContext;
    private readonly IBound _objectBound;

    public RegisterObjectBoundSystem (Contexts contexts, IBound worldBound) {
        _metaContext = contexts.meta;
        _objectBound = worldBound;
    }

    public void Initialize () {
        _metaContext.ReplaceObjectBoundService (_objectBound);
    }
}