using Entitas;

public class RegisterPhysicsSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IPhysics _physics;

    public RegisterPhysicsSystem(Contexts contexts, IPhysics physics)
    {
        _metaContext = contexts.meta;
        _physics = physics;
    }

    public void Initialize()
    {
        _metaContext.ReplacePhysicsService(_physics);
    }
}