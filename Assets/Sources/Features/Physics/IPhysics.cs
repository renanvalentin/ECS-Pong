using System.Collections.Generic;
using Entitas;
using UnityEngine;

public interface IPhysics {
    List<RaycastHit2D> RigidbodyCast (IRigidbody rigidbody, Vector2 direction, float distance);
    int SphereCast (Vector2 position, float radius, RaycastHit2D[] buffer, int layerMask);
    int OverlapCircle (Vector2 position, float radius, Collider2D[] buffer, int layerMask);
}