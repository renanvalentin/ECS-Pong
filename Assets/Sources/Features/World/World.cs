using UnityEngine;

public class World
{
    public int Height { get; private set; }
    public int Width { get; private set; }

    public World(int height, int width)
    {
        Height = height;
        Width = width;
    }
}