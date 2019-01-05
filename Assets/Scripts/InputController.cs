using System.Text;
using GamepadInput;
using UnityEngine;

public class InputController : MonoBehaviour {
    [Range (1, 2)]
    public int player;

    private const float _axisDeadZone = 0.4f;
    private IView _view;

    private string horizontal;
    private string vertical;
    private string jump;

    public void Awake () {
        _view = GetComponent<IView> ();

        horizontal = "Player" + (player - 1) + "Horizontal";
        vertical = "Player" + (player - 1) + "Vertical";
        jump = "Player" + (player - 1) + "Jump";
    }

    public void Update () {
        GameEntity gameEntity = (GameEntity) _view.GetEntity ();
        string playerId = gameEntity.player.id;

        // if (Input.GetAxis (horizontal) < 0) {
        //     CreateInputEntity (gameEntity, InputButton.Left);
        // } else if (Input.GetAxis (horizontal) > 0) {
        //     CreateInputEntity (gameEntity, InputButton.Right);
        // }

        // if (Input.GetAxis (vertical) > 0) {
        //     CreateInputEntity (gameEntity, InputButton.Up);
        // } else if (Input.GetAxis (vertical) < 0) {
        //     CreateInputEntity (gameEntity, InputButton.Down);
        // }

        if (Input.GetButtonDown (jump)) {
            CreateInputEntity (gameEntity, InputButton.Fire);
        }

        CreateInputAxis (gameEntity);
    }

    private void CreateInputEntity (GameEntity entity, InputButton button) {
        InputEntity input = Contexts.sharedInstance.input.CreateEntity ();
        input.AddInputOwner (entity.player.id);
        input.AddInput (button);
    }

    private void CreateInputAxis (GameEntity entity) {
        InputEntity input = Contexts.sharedInstance.input.CreateEntity ();
        input.AddInputOwner (entity.player.id);
        input.AddInputAxis (new Vector2 (Input.GetAxisRaw (horizontal), Input.GetAxisRaw (vertical)));
    }
}