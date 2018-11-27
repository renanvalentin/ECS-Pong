using System.Collections.Generic;
using Entitas;
using UnityEngine;

public interface IPhysics
{
    List<RaycastHit2D> RigidbodyCast(IRigidbody rigidbody, Vector2 direction, float distance);
}