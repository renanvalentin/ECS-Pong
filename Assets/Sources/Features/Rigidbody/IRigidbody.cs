using UnityEngine;

public interface IRigidbody
{
    ContactFilter2D Filter { get; }

    int Cast(Vector2 direction, float distance, RaycastHit2D[] buffer, ContactFilter2D contactFilter2D);
}