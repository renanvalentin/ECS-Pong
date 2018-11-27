using UnityEngine;

public class ScreenBound : IBound
{
    private readonly Vector2 _min;
    private readonly Vector2 _max;
    
    public Vector2 Min
    {
        get { return _min; }
    }
    
    public Vector2 Max
    {
        get { return _max; }
    }

    public float Width { get; private set; }
    public float Height { get; private set; }

    public bool ContainsX(float x)
    {
        return x >= _min.x && x <= _max.x;
    }

    public bool ContainsY(float y)
    {
        return y >= _min.y && y <= _max.y;
    }

    public float ClampX(float x)
    {
        throw new System.NotImplementedException();
    }

    public float ClampY(float y)
    {
        throw new System.NotImplementedException();
    }

    public ScreenBound(ICamera camera)
    {
        var screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.Position.z));
        
        _min = new Vector2(screenBounds.x * -1, screenBounds.y * -1);
        _max = new Vector2(screenBounds.x, screenBounds.y);
    }
}