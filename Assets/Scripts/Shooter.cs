using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private Vector2 _bulletSpawnOffset;

    private int _direction;

    public event Func<Vector2, Bullet> Shooting;

    private void Awake()
        => _direction = Math.Sign(transform.up.x);

    public void Shoot()
    {
        Vector2 spawningPosition = (Vector2)transform.position + _bulletSpawnOffset * _direction;
        Bullet bullet = Shooting?.Invoke(spawningPosition);
        bullet.Mover.SetSpeed(transform.up * _speedX);
    }
}