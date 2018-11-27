public class Services {
    public readonly IBound ScreenBound;
    public readonly IBound WorldBound;
    public readonly IBound ObjectBound;
    public readonly IPhysics Physics;

    public Services (IBound screenBound, IBound worldBound, IPhysics physics, IBound objectBound) {
        ScreenBound = screenBound;
        WorldBound = worldBound;
        ObjectBound = objectBound;
        Physics = physics;
    }
}