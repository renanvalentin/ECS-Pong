public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterScreenBoundSystem(contexts, services.ScreenBound));
        Add(new RegisterPhysicsSystem(contexts, services.Physics));
        Add(new RegisterWorldBoundSystem(contexts, services.WorldBound));
    }
}