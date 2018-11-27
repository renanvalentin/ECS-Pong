using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class UnityPhysicsService : IPhysics
{
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    public List<RaycastHit2D> RigidbodyCast(IRigidbody rigidbody, Vector2 direction, float distance)
    {
        int count = rigidbody.Cast(direction, distance, hitBuffer, rigidbody.Filter);

        hitBufferList.Clear();

        for (int i = 0; i < count; i++)
        {          
            hitBufferList.Add(hitBuffer[i]);
        }

        return hitBufferList;
    }
}