using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : Component, ISpawnable
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;

    private ObjectPool<T> _pool;
    private List<T> _activeElements;

    private void Awake()
    {
        _pool = new(Create, GetElement, ReleaseElement, Destroy);
        _activeElements = new List<T>();
    }

    public void ReleaseActiveElements()
    {
        for(int i = _activeElements.Count - 1; i >= 0; i--)
            Release(_activeElements[i]);
    }

    public virtual T GetElement(Vector2 position)
    {
        T element = _pool.Get();
        _activeElements.Add(element);

        element.transform.position = position;
        element.Releasing += Release;

        return element;
    }

    protected virtual void Release(ISpawnable element)
    {
        element.Releasing -= Release;

        _activeElements.Remove((T)element);
        _pool.Release((T)element);
    }

    private T Create()
    {
        T element = Instantiate(_prefab, _container);

        return element;
    }

    private void GetElement(T element)
        => element.gameObject.SetActive(true);

    private void ReleaseElement(T element)
        => element.gameObject.SetActive(false);

    private void Destroy(T element)
        => Destroy(element.gameObject);
}