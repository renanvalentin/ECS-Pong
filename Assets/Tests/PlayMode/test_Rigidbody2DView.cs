using System.CodeDom;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class Rigidbody2DViewTest
{
    Contexts contexts = null;
    
    GameEntity _player = null;
    GameEntity _wall = null;
    GameEntity _floor = null;

    private GameEntity CreateEntity(Vector2 position)
    {
        var e = contexts.game.CreateEntity();
        e.AddPosition(position);

        return e;
    }

    [SetUp]
    public void Setup()
    {
        contexts = new Contexts();

        _player = CreateEntity(new Vector2(-2f, -0.025f));
        _wall = CreateEntity(new Vector2(2f, 0));
        _floor = CreateEntity(new Vector2(0, -1.107f));
    }
    
    [UnityTest]
    public IEnumerator Test_Horizontal_Casting()
    {
        SceneManager.LoadScene("Rigidbody2DViewTest", LoadSceneMode.Single);

        yield return null;

        var player = GameObject.Find("Player");
        var wall = GameObject.Find("Wall");

        player.GetComponent<IView>().Link(_player, contexts.game);
        wall.GetComponent<IView>().Link(_wall, contexts.game);

        player.GetComponent<Rigidbody2D>().position = new Vector2(0, 0);

        yield return new WaitForFixedUpdate();
        
        Assert.False(_player.hasRaycastCollision);

        player.GetComponent<Rigidbody2D>().velocity = Vector2.right;
        player.GetComponent<Rigidbody2D>().position = new Vector2(1, 0);

        yield return new WaitForFixedUpdate();
        
        Assert.True(_player.hasRaycastCollision);
    }
    
    [UnityTest]
    public IEnumerator Test_Vertical_Casting()
    {
        SceneManager.LoadScene("Rigidbody2DViewTest", LoadSceneMode.Single);

        yield return null;

        var player = GameObject.Find("Player");
        var floor = GameObject.Find("Floor");

        player.GetComponent<IView>().Link(_player, contexts.game);
        floor.GetComponent<IView>().Link(_floor, contexts.game);

        player.GetComponent<Rigidbody2D>().position = new Vector2(0, 0);

        yield return new WaitForFixedUpdate();
        
        Assert.False(_player.hasRaycastCollision);

        player.GetComponent<Rigidbody2D>().velocity = Vector2.down;
        player.GetComponent<Rigidbody2D>().position = new Vector2(-1, 0);

        yield return new WaitForFixedUpdate();
        
        Assert.True(_player.hasRaycastCollision);
    }
}