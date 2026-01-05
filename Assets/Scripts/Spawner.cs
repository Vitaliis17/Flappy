using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    private Pool<Bullet> _spawnerBullet;

    public event Action Disabling;

    private void Awake()
        => _spawnerBullet = new(_bullet);

    private void OnDisable()
        => Disabling?.Invoke();

    public Bullet GetBullet()
        => _spawnerBullet.Get();
}