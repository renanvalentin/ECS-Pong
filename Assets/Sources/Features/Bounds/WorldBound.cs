using UnityEngine;

public class WorldBound : IBound
{
    private readonly Vector2 _min;
    private readonly Vector2 _max;

    private readonly World _world;

    public WorldBound(World world)
    {
        _world = world;
    }

    public Vector2 Min
    {
        get { return _min; }
    }

    public Vector2 Max
    {
        get { return _max; }
    }

    public float Width
    {
        get { return _world.Width; }
    }

    public float Height
    {
        get { return _world.Height; }
    }

    public bool ContainsX(float x)
    {
        return x >= 0 && x <= _world.Width;
    }

    public bool ContainsY(float y)
    {
        return y >= 0 && y <= _world.Height;
    }

    public float ClampX(float x)
    {
        return Mathf.Clamp(x, 0, Width);
    }

    public float ClampY(float y)
    {
        return Mathf.Clamp(y, 0, Height);
    }
}