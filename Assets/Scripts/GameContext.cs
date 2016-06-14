using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.pool.api;

public class GameContext : MVCSContext {
    public GameContext() : base() {
    }

    public GameContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) {
    }

    protected override void addCoreComponents() {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings() {
        // View bindings.
        mediationBinder.Bind<GameManagerView>().To<GameManagerMediator>();
        mediationBinder.Bind<PlayerView>().To<PlayerMediator>();

        // Command bindings.
        commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
        commandBinder.Bind<SpawnPlayerSignal>().To<SpawnPlayerCommand>();
    }

    protected override void postBindings() {
        base.postBindings();
    }

    private void SetupObjectPool(string resourcePath, IPool pool) {
        pool.instanceProvider = new ResourceInstanceProvider(resourcePath, LayerMask.NameToLayer("Default"));
        pool.inflationType = PoolInflationType.INCREMENT;
    }
}
