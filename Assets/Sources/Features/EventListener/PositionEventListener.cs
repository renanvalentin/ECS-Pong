//using Entitas;
//using UnityEngine;
//
//public class PositionEventListener : MonoBehaviour, IEventListener, IPositionListener {
//    GameEntity _entity;
// 
//    public void RegisterListeners(IEntity entity) {
//        _entity = (GameEntity)entity;
//        _entity.AddPositionListener(this);
//    }
//
//    public void OnPosition(GameEntity e, Vector2 newPosition)
//    {
//        transform.position = newPosition;
//    }
//}