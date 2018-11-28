using Entitas;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameController : MonoBehaviour {
    public int worldWidth = 5;
    public int worldHeight = 5;

    public Vector2 ballVelocity = new Vector2 (.1f, 0f);
    public Vector2 ballVelocity2 = new Vector2 (-1.1f, 0f);
    public int speed = 10;

    public int amount = 30;

#if UNITY_EDITOR
    public bool debug = true;
#endif

    Systems _serviceSystems;
    Systems _gameSystems;
    Systems _updateSystems;
    Systems _fixedUpdateSystems;
    Contexts _contexts;
    World _world;

    void Awake () {
        _contexts = Contexts.sharedInstance;

        ViewService.singleton.Initialize (_contexts, this.transform);

        _world = new World (worldHeight, worldWidth);

        var services = new Services (new ScreenBound (new UnityCamera ()), new WorldBound (_world), new UnityPhysicsService (), new ObjectBound (_world));

        _serviceSystems = new ServiceRegistrationSystems (_contexts, services);
        _serviceSystems.Initialize ();

        _gameSystems = new GameSystems (_contexts);
    }

    void Start () {
        _gameSystems.Initialize ();

        float maxRigid = amount * .1f;

        for (int i = 0; i < amount; i++) {
            GameEntity entity = CreateEntity (i);

            if (i < maxRigid) {
                entity.AddAsset ("ball");
            } else {
                entity.AddAsset ("ball2");
            }
        }

        float playableArea = worldHeight / 3;

        Debug.Log (playableArea);
        Debug.Log (worldHeight - playableArea);

        CreatePlayer (new Vector2 (0, 0), new Vector2 (0, 0), new Vector2 (worldWidth, playableArea), "player_1");
        // CreatePlayer (new Vector2 (0, worldHeight), new Vector2 (0, worldHeight - playableArea), new Vector2 (worldWidth, worldHeight), "player_2");

    }

    private void CreatePlayer (Vector2 position, Vector2 minBound, Vector2 maxBound, string id) {
        GameEntity e = _contexts.game.CreateEntity ();
        e.AddPosition (position);
        e.AddVelocity (Vector2.zero);
        e.AddShellRadius (0.01f);
        e.AddBound (minBound, maxBound);
        e.AddAsset (id);
        e.AddPlayer (id);
        e.AddCollisionLayer ("Player");
        e.AddRaycastRadius (2);
        e.isWorldClamp = true;
    }

    private GameEntity CreateEntity (int i) {
        GameEntity entity = _contexts.game.CreateEntity ();
        entity.AddPosition (new Vector2 (i + 2, i + 2));
        entity.AddSpeed (Random.Range (1, speed));
        entity.AddShellRadius (0.01f);
        entity.isWorldClamp = true;
        entity.isBounce = true;

        entity.AddVelocity (new Vector2 (Random.Range (-2, 2), Random.Range (-2, 2)));
        entity.AddConstantVelocity (ballVelocity);
        return entity;
    }

    void Update () {
        _gameSystems.Execute ();
        _gameSystems.Cleanup ();
    }

    void OnDestroy () {
        _gameSystems.TearDown ();
        _serviceSystems.TearDown ();
    }
}