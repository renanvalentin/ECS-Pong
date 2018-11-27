using Entitas;

public sealed class GameSystems : Feature {
    public GameSystems (Contexts contexts) {
        // Tick
        Add (new TickSystem (contexts));

        // Input
        Add (new InputSystem (contexts));
        Add (new ProcessMoveInputSystem (contexts));

        // Velocity
        Add (new ConstantVelocity (contexts));
        Add (new VelocitySystem (contexts));

        // Raycast & Collision emit
        Add (new EmitRaycastSystem (contexts));
        Add (new EmitCollisionSystem (contexts));

        // Resolve collisions
        Add (new HorizontalMinimumTranslationSystem (contexts));
        Add (new VerticalMinimumTranslationSystem (contexts));

        // On Collision
        Add (new BounceCollisionSystem (contexts));

        // Apply position
        Add (new PositionSystem (contexts));

        Add (new WorldBounceSystem (contexts));
        Add (new WorldClampSystem (contexts));
        Add (new PlayerBoundariesClampSystem (contexts));

        // Events
        Add (new GameEventSystems (contexts));

        // Cleanup
        Add (new ColliderCleanupSystem (contexts));
        Add (new CollisionCleanupSystem (contexts));
        Add (new DestroyEntitySystem (contexts));
    }
}