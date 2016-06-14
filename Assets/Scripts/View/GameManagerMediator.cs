using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class GameManagerMediator : Mediator {
    [Inject]
    public GameManagerView View { get; set; }

    [Inject]
    public StartGameSignal StartGameSignal { get; set; }

    public override void OnRegister() {
        StartGameSignal.Dispatch();    
    }

    void Update () {
	
	}
}
