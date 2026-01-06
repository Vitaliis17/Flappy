using UnityEngine;
using UnityEngine.Pool;
using System;

public abstract class BaseSpawner<T> : MonoBehaviour where T : Component
{
    protected ObjectPool<T> Pool;

    [SerializeField] private T _prefab;
    [SerializeField] private Transform _folder;

    public event Action Disabling;

    private void Awake()
        => Pool = new(Create, GetElement, ReleaseElement, Destroy);
 
    private void OnDisable()
        => Disabling?.Invoke();

    public void Release(T element)
        => Pool.Release(element);

    public T GetBullet()
        => Pool.Get();

    private T Create()
        => Instantiate(_prefab, _folder);

    private void GetElement(T element)
        => element.gameObject.SetActive(true);

    private void ReleaseElement(T element)
        => element.gameObject.SetActive(false);

    private void Destroy(T element)
        => Destroy(element.gameObject);
}