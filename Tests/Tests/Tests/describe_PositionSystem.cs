//using NSpec;
//using UnityEngine;
//
//class describe_PositionSystem : nspec
//{
//    void when_executing()
//    {
//        it["applies velocity to position"] = () =>
//        {
//            var contexts = new Contexts();
//            contexts.meta.ReplaceDeltaTime(1);
//            
//            var system = new PositionSystem(contexts);
//            var e = contexts.game.CreateEntity();
//            
//            e.AddVelocity(Vector2.right + Vector2.down);
//            e.AddPosition(Vector2.zero);
//            
//            system.Execute();
//            
//            e.position.value.should_be(Vector2.right + Vector2.down);
//        };
//    }
//}