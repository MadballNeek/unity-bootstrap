//This is a common service/model pattern in Strange:
//We want something usually reserved to MonoBehaviours to be available
//elsewhere. Maybe someday we'll write a version that
//eschews MonoBehaviours altogether...but for now we simply leverage
//that behavior and provide it in injectable form.

//In this case, we're making Coroutines available everywhere in the app
//by attaching a MonoBehaviour to the ContextView.

//IRoutineRunner can be injected anywhere, minimizing direct dependency
//on MonoBehaviours.

using System.Collections;
using strange.extensions.context.api;
using UnityEngine;


public class RoutineRunner : IRoutineRunner {
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject ContextView { get; set; }

    private RoutineRunnerBehaviour _monoBehavior;

    [PostConstruct]
    public void PostConstruct() {
        // Attach the routine runners to the Root and not directly onto the ContextView.
        // This will help when we destroy the root when we leave a scene.
        _monoBehavior = ContextView.transform.Find("Root").gameObject.AddComponent<RoutineRunnerBehaviour>();            
    }

    public Coroutine StartCoroutine(IEnumerator routine) {
        return _monoBehavior.StartCoroutine(routine);
    }

    public void StopAllCoroutines() {
        _monoBehavior.StopAllCoroutines();
    }

    public void RemoveRoutineRunner() {
        Object.Destroy(_monoBehavior);
    }
}

public class RoutineRunnerBehaviour : MonoBehaviour {

    void OnDestroy() {
        StopAllCoroutines();
    }
}