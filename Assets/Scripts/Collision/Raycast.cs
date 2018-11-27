using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class Raycast  {
    protected ContactFilter2D _contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody2D;
    private float _slopeDetectionMargin;
    
    private Vector3 position;

    public Raycast(BoxCollider2D boxCollider, Rigidbody2D rigidbody2D, ContactFilter2D contactFilter)
    {
        _boxCollider = boxCollider;
        _rigidbody2D = rigidbody2D;
        
        _slopeDetectionMargin = _boxCollider.size.y * 0.5f;

        _contactFilter = contactFilter;
        
        this.Setup();
    }
    
    private void Setup () 
    {
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (_rigidbody2D.gameObject.layer));
        _contactFilter.useLayerMask = true;
    }

    public RaycastHit2D? Cast(Vector2 direction, float distance, float shellRadius)
    {
        Debug.DrawRay(_rigidbody2D.transform.position, direction * (distance + shellRadius));
        int count = _rigidbody2D.Cast (direction, _contactFilter, hitBuffer, distance + shellRadius);
        
        hitBufferList.Clear ();

        for (int i = 0; i < count; i++) {
            hitBufferList.Add (hitBuffer [i]);
        }

        for (int i = 0; i < hitBufferList.Count; i++) 
        {
            return hitBufferList[i];
        }

        return null;
    }
}
