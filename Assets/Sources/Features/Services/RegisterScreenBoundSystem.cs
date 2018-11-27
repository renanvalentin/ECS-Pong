using Entitas;

public class RegisterScreenBoundSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IBound _screenBound;

    public RegisterScreenBoundSystem(Contexts contexts, IBound screenBound)
    {
        _metaContext = contexts.meta;
        _screenBound = screenBound;
    }

    public void Initialize()
    {
        _metaContext.ReplaceScreenBoundService(_screenBound);
    }
}