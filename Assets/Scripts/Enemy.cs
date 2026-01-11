using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour, ISpawnable, IHasHealth
{
    [SerializeField] private EnemyData _data;
    [SerializeField] private Shooter _shooter;

    private Timer _timer;
    private Coroutine _coroutine;

    public event Action<ISpawnable> Releasing;

    public Health Health { get; private set; }
    public Shooter Shooter => _shooter;

    private void Awake()
        => _timer = new();

    private void OnEnable()
    {
        Health = new(_data.MaxHealthAmount);

        _coroutine = StartCoroutine(_timer.WaitPeriodically(_data.ShootingPeriodicity));

        _timer.TimeOvered += _shooter.Shoot;
        Health.Died += Die;
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);

        _timer.TimeOvered -= _shooter.Shoot;
        Health.Died -= Die;
    }

    private void Die()
        => Releasing?.Invoke(this);
}