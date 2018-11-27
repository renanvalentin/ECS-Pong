using System.Collections.Generic;
using Entitas;
using UnityEngine;

//public sealed class PositionSystem : ReactiveSystem<GameEntity>
//{
//    public PositionSystem(Contexts contexts) : base(contexts.game)
//    {
//    }
//
//    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//    {
//        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Velocity));
//    }
//
//    protected override bool Filter(GameEntity entity)
//    {
//        return entity.hasPosition;
//    }
//
//    protected override void Execute(List<GameEntity> entities)
//    {
//        foreach (var entity in entities)
//        {
//            Vector2 position = entity.position.value + entity.velocity.value;
//            entity.ReplacePosition(position);
//        }
//    }
//}


public sealed class PositionSystem : IExecuteSystem
{
//    private readonly MetaContext _meta;

    IGroup<GameEntity> _group;

    public PositionSystem(Contexts contexts)
    {
        _group = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Velocity, GameMatcher.Position));
//        _meta = contexts.meta;
    }

    public void Execute()
    {
        foreach (var entity in _group.GetEntities())
        {
//            entity.ReplacePosition(entity.position.value + entity.velocity.value);
            entity.ReplacePosition(entity.position.value + entity.velocity.value);
//            entity.ReplacePosition(new Vector2(entity.position.value.x, entity.position.value.y + 1));
        }
    }
}