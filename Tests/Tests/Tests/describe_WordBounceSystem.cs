using NSpec;
using UnityEngine;

class describe_WorldBounceSystem : nspec
{
    void when_executing()
    {
        Contexts contexts = null;
        WorldBounceSystem system = null;
        GameEntity e = null;
        World world = null;

        before = () =>
        {
            contexts = new Contexts();

            world = new World(1, 1);
            contexts.meta.ReplaceWorldBoundService(new WorldBound(world));

            system = new WorldBounceSystem(contexts);
            e = contexts.game.CreateEntity();
        };

        it["change the vertical direction when it hits the top of the world"] = () =>
        {
            e.AddVelocity(Vector2.up);
            e.AddPosition(new Vector2(0, world.Height + 1));

            system.Execute();

            e.velocity.value.should_be(Vector2.down);
        };

        it["change the vertical direction when it hits the bottom of the world"] = () =>
        {
            e.AddVelocity(Vector2.down);
            e.AddPosition(Vector2.down);

            system.Execute();

            e.velocity.value.should_be(Vector2.up);
        };

        it["change the horizontal direction when it hits the left side of the world"] = () =>
        {
            e.AddVelocity(Vector2.left);
            e.AddPosition(Vector2.left);

            system.Execute();

            e.velocity.value.should_be(Vector2.right);
        };

        it["change the horizontal direction when it hits the right side of the world"] = () =>
        {
            e.AddVelocity(Vector2.right);
            e.AddPosition(new Vector2(world.Width + 1, 0));

            system.Execute();

            e.velocity.value.should_be(Vector2.left);
        };
    }
}