using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class UnityPhysicsService : IPhysics {
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

    public List<RaycastHit2D> RigidbodyCast (IRigidbody rigidbody, Vector2 direction, float distance) {
        int count = rigidbody.Cast (direction, distance, hitBuffer, rigidbody.Filter);

        hitBufferList.Clear ();

        for (int i = 0; i < count; i++) {
            hitBufferList.Add (hitBuffer[i]);
        }

        return hitBufferList;
    }

    public int SphereCast (Vector2 position, float radius, RaycastHit2D[] buffer, int layerMask) {
        return Physics2D.CircleCastNonAlloc (position, radius, Vector2.down, buffer, radius, layerMask);
    }

    public int OverlapCircle (Vector2 position, float radius, Collider2D[] buffer, int layerMask) {
        return Physics2D.OverlapCircleNonAlloc (position, radius, buffer, layerMask);
    }
}