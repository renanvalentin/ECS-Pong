using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class MinimumTranslationSystem : ReactiveSystem<GameEntity>
{
    readonly IGroup<GameEntity> _rayCasts;
    private readonly MetaContext _meta;


    public MinimumTranslationSystem(Contexts contexts) : base(contexts.game)
    {
        _rayCasts = contexts.game.GetGroup(GameMatcher.RaycastCollision);
        _meta = contexts.meta;     

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.RaycastCollision));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasVelocity && entity.hasShellRadius && entity.hasRaycastCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var collision = entity.raycastCollision;

            float modifiedDistance = collision.friction - entity.shellRadius.value;
            float distance = modifiedDistance < collision.rayLenth ? modifiedDistance : collision.rayLenth;

            Vector2 nextVelocity  = entity.velocity.value.normalized * distance;
            entity.ReplaceVelocity(nextVelocity);
        }
    }
}