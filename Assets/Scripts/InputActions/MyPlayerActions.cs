using UnityEngine;
using System.Collections;
using InControl;

public class MyPlayerActions : PlayerActionSet {
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerTwoAxisAction Move;

    public MyPlayerActions() {
        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }
}
