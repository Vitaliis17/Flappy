using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour, ISpawnable
{
    [SerializeField] private Health _health;

    public event Action<ISpawnable> Releasing;

    public Health Health { get { return _health; } }

    private void OnEnable()
    {
        _health.Initialize();
        _health.Died += Die;
    }

    private void OnDisable()
        => _health.Died -= Die;

    private void Die()
        => Releasing?.Invoke(this);
}