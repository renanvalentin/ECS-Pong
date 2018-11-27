using NSpec;
using UnityEngine;

class describe_VelocitySystem : nspec
{
    void when_executing()
    {
        Contexts contexts = null;
        VelocitySystem system = null;
        GameEntity e = null;
        World world = null;

        before = () =>
        {
            contexts = new Contexts();
            contexts.meta.ReplaceDeltaTime(1);

            system = new VelocitySystem(contexts);
            e = contexts.game.CreateEntity();
        };

        it["changes the position by velocity at specific rate"] = () =>
        {
            int speed = 5;
            
            e.AddVelocity(Vector2.up);
            e.AddPosition(Vector2.zero);
            e.AddSpeed(speed);

            system.Execute();

            e.position.value.should_be(new Vector2(0, speed));
        };
    }
}