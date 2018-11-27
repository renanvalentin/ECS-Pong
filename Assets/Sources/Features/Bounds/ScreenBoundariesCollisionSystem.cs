using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ScreenBoundariesCollisionSystem  :  ReactiveSystem<GameEntity>
{
    IBound _worldBound;
    
    public ScreenBoundariesCollisionSystem (Contexts contexts) : base(contexts.game)
    {
       _worldBound = contexts.meta.worldBoundService.instance;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            
            if (!_worldBound.ContainsX(entity.position.value.x))
            {
                entity.ReplaceVelocity(new Vector2(entity.velocity.value.x * -1, entity.velocity.value.y));
            }
            else if (!_worldBound.ContainsY(entity.position.value.y))
            {
                entity.ReplaceVelocity(new Vector2(entity.velocity.value.x, entity.velocity.value.y  * -1));
            }
        }
    }
}