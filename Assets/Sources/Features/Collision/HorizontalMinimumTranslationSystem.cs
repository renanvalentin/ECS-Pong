using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HorizontalMinimumTranslationSystem : ReactiveSystem<GameEntity>
{
    readonly IGroup<GameEntity> _rayCasts;
    private readonly MetaContext _meta;


    public HorizontalMinimumTranslationSystem(Contexts contexts) : base(contexts.game)
    {
        _rayCasts = contexts.game.GetGroup(GameMatcher.HorizontalRaycastCollision);
        _meta = contexts.meta;     

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.RaycastCollision));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasVelocity && entity.hasShellRadius && entity.isHorizontalRaycastCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var collision = entity.raycastCollision;

            float modifiedDistance = collision.friction - entity.shellRadius.value;
            float distance = modifiedDistance < collision.rayLenth ? modifiedDistance : collision.rayLenth;
            
            Vector2 nextVelocity  = entity.velocity.value.normalized * distance;
            entity.ReplaceVelocity(new Vector2(nextVelocity.x, entity.velocity.value.y));
        }
    }
}