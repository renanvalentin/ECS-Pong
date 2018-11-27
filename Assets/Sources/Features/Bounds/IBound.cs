using UnityEngine;

public interface IBound
{
    Vector2 Min { get; }
    Vector2 Max { get; }
    
    float Width { get; }
    float Height { get; }

    bool ContainsX(float x);
    bool ContainsY(float y);

    float ClampX(float x);
    float ClampY(float y);
}