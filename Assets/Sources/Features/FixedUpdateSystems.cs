using Entitas;

public sealed class FixedUpdateSystems : Feature
{
    public FixedUpdateSystems(Contexts contexts)
    {
        // Tick
        Add(new TickSystem(contexts));
        
        // Update
//        Add(new MoveSystem(contexts));

        Add(new WorldBounceSystem(contexts));
        Add(new WorldClampSystem(contexts));

//        Add(new HorizontalMinimumTranslationSystem(contexts));
//        Add(new VerticalMinimumTranslationSystem(contexts));
        Add(new VelocitySystem(contexts));
//        Add(new PositionSystem(contexts));
        

        // Events
        Add(new GameEventSystems(contexts));

        // Cleanup
        Add(new DestroyEntitySystem(contexts));
    }
}