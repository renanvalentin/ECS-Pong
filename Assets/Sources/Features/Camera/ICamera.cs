using System.Linq.Expressions;
using UnityEngine;

public interface ICamera
{
    Vector3 ScreenToWorldPoint(Vector3 screen);
    
    Vector3 Position { get; }
}