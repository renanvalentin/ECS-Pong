using NSpec;
using UnityEngine;

class describe_WorldClampSystem : nspec
{
    void when_executing()
    {
        Contexts contexts = null;
        WorldClampSystem system = null;
        GameEntity e = null;
        World world = null;

        before = () =>
        {
            contexts = new Contexts();

            world = new World(1, 1);
            contexts.meta.ReplaceWorldBoundService(new WorldBound(world));

            system = new WorldClampSystem(contexts);
            e = contexts.game.CreateEntity();
        };

        it["clamps horizontal position when out of the world boundaries"] = () =>
        {
            e.isWorldClamp = true;
            e.AddPosition(new Vector2(world.Width + .1f, 0));

            system.Execute();

            e.position.value.should_be(new Vector2(world.Width, 0));
        };
       
        it["should not clamp a value in between the expected range"] = () =>
        {
            e.isWorldClamp = true;
            e.AddPosition(new Vector2(.5f, 0));

            system.Execute();

            e.position.value.should_be(new Vector2(.5f, 0));
        };

        it["clamps vertical position when out of the world boundaries"] = () =>
        {
            e.isWorldClamp = true;
            e.AddPosition(new Vector2(0, world.Height + .1f));

            system.Execute();

            e.position.value.should_be(new Vector2(0, world.Height));
        };
    }
}