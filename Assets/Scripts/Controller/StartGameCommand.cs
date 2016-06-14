using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class StartGameCommand : Command {

    [Inject]
    public SpawnPlayerSignal SpawnPlayerSignal { get; set; }

    public override void Execute() {
        SpawnPlayerSignal.Dispatch();
    }
}
