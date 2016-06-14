using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class SpawnPlayerCommand : Command {
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject ContextView { get; set; }

    public override void Execute() {        
        GameObject playerGo = new GameObject("Player");
        playerGo.layer = LayerMask.NameToLayer("Player");
        playerGo.transform.parent = ContextView.transform;
        playerGo.transform.position = Vector2.zero;        
        // Set sprite.
        //tk2dSprite sprite = playerGo.AddComponent<tk2dSprite>();
        //sprite.Collection = Resources.Load("sprites/GameSpriteCollection Data/GameSpriteCollection", typeof(tk2dSpriteCollectionData)) as tk2dSpriteCollectionData;    
        //sprite.SetSprite(0);
        //sprite.Build();
        // Set collider and rigidbody.        
        Rigidbody2D rigidbody = playerGo.AddComponent<Rigidbody2D>();
        rigidbody.isKinematic = true;
        // Set view.
        playerGo.AddComponent<PlayerView>();
    }
}
