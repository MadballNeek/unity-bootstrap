using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using InControl;

public class PlayerMediator : Mediator {
    private MyPlayerActions _playerActions;

    [Inject]
    public PlayerView View { get; set; }

    public override void OnRegister() {
        _playerActions = new MyPlayerActions();
        _playerActions.Left.AddDefaultBinding(Key.LeftArrow);
        _playerActions.Left.AddDefaultBinding(Key.A);
        _playerActions.Right.AddDefaultBinding(Key.RightArrow);
        _playerActions.Right.AddDefaultBinding(Key.D);
        _playerActions.Up.AddDefaultBinding(Key.UpArrow);
        _playerActions.Up.AddDefaultBinding(Key.W);
        _playerActions.Down.AddDefaultBinding(Key.DownArrow);
        _playerActions.Down.AddDefaultBinding(Key.S);
    }

    public override void OnRemove() {
        _playerActions.Destroy();
    }

    void FixedUpdate () {
        rigidbody2D.AddForce(new Vector2(_playerActions.Move.Value.x, 0), ForceMode2D.Impulse);
        Vector2 velocity = rigidbody2D.velocity;
        rigidbody2D.velocity = new Vector2(Mathf.Clamp(velocity.x, -5, 5), Mathf.Clamp(velocity.y, -5, 5));
	}
}
