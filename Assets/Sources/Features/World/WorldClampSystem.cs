using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class WorldClampSystem : ReactiveSystem<GameEntity>
{
    IBound _worldBound;

    public WorldClampSystem(Contexts contexts) : base(contexts.game)
    {
        _worldBound = contexts.meta.worldBoundService.instance;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.WorldClamp));
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            Vector2 position = entity.position.value;

            float x = position.x;
            float y = position.y;

            if (!_worldBound.ContainsX(position.x))
            {
                x = _worldBound.ClampX(position.x);
            }

            if (!_worldBound.ContainsY(y))
            {
                y = _worldBound.ClampY(y);
            }

            entity.ReplacePosition(new Vector2(x, y));
        }
    }
}