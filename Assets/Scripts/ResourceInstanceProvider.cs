using System;
using strange.framework.api;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Pools require an instance provider to instantiate instances.
/// Quite often we can leave this job to the InjectionBinder...but when prefabs
/// are involved, we need to override the default behavior and do some of the
/// work ourselves.
/// </summary>
public class ResourceInstanceProvider : IInstanceProvider {
    // The GameObject instantiated from the prefab
    private GameObject _prototype;

    // The name of the resource in Unity's resources folder
    private readonly string _resourceName;
    // The render layer to which the GameObjects will be assigned
    private readonly int _layer;
    // An id tacked on to the name to make it easier to track individual instances
    private int _id;

    // This provider is instantiated multiple times in the game's context.
    // Each time, we provide the name of the prefab we're loading from
    // a resources folder, and the layer to which the resulting instance
    // is added too.
    public ResourceInstanceProvider(string name, int layer) {
        _resourceName = name;
        _layer = layer;
    }

    #region IInstanceProvider implementation
    // Generate a typed instance
    public T GetInstance<T>() {
        object instance = GetInstance(typeof(T));
        T retv = (T) instance;
        return retv;
    }

    // Generate an untyped instance
    public object GetInstance(Type key) {
        if (_prototype == null) {
            // Get the resource from Unity
            _prototype = Resources.Load<GameObject>(_resourceName);
            _prototype.transform.localScale = Vector3.one;
        }

        // Copy the prototype
        GameObject go = Object.Instantiate(_prototype) as GameObject;
        go.layer = _layer;
        go.name = _resourceName + "_" + _id++;

        return go;
    }
    #endregion    
}
