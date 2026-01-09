using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : Component, ISpawnable
{
    protected ObjectPool<T> Pool;

    [SerializeField] private T _prefab;
    [SerializeField] private Transform _folder;

    public event Action Disabling;

    protected virtual void Awake()
        => Pool = new(Create, GetElement, ReleaseElement, Destroy);
 
    private void OnDisable()
        => Disabling?.Invoke();

    protected virtual void Release(ISpawnable element)
    {
        element.Releasing -= Release;

        Pool.Release((T)element);
    }

    public virtual T GetElement(Vector2 position)
    {
        T element = Pool.Get();

        element.transform.position = position;
        element.Releasing += Release;

        return element;
    }

    private T Create()
        => Instantiate(_prefab, _folder);

    private void GetElement(T element)
        => element.gameObject.SetActive(true);

    private void ReleaseElement(T element)
        => element.gameObject.SetActive(false);

    private void Destroy(T element)
        => Destroy(element.gameObject);
}