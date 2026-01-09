using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour, ISpawnable, IHealthable
{
    [SerializeField] private EnemyData _data;
    [SerializeField] private Shooter _shooter;

    private Health _health;

    private Timer _timer;
    private Coroutine _coroutine;

    public event Action<ISpawnable> Releasing;

    public Health Health => _health;
    public Shooter Shooter => _shooter;

    public void Awake()
    {
        _health = new(_data.MaxHealthAmount);
        _timer = new();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(_timer.WaitPeriodically(_data.ShootingPeriodicity));

        _timer.TimeOvered += _shooter.Shoot;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);

        _timer.TimeOvered -= _shooter.Shoot;
        _health.Died -= Die;
    }

    private void Die()
        => Releasing?.Invoke(this);
}