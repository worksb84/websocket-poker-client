using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        var go = Resources.Load<T>(path);
        return go;
    }

    public GameObject Instantiate(string path, string name = null)
    {
        var original = Load<GameObject>(path);
        var go = Object.Instantiate(original);
        go.name = name == null ? original.name : $"{name}";
        return go;
    }
}