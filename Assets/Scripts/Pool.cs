using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> where T : Component
{
    private ObjectPool<T> _pool;

    private T _prefab;

    public Pool(T prefab)
    {
        _pool = new(Create, GetElement, ReleaseElement, Destroy);

        _prefab = prefab;
    }

    public T Get()
        => _pool.Get();

    public void Release(T a)
        => _pool.Release(a);

    private T Create()
        => Object.Instantiate(_prefab);

    private void GetElement(T element)
        => element.gameObject.SetActive(true);

    private void ReleaseElement(T element)
        => element.gameObject.SetActive(false);

    private void Destroy(T element)
        => Object.Destroy(element.gameObject);
}