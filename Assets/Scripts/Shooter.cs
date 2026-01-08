using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private Vector2 _bulletSpawnOffset;

    public event Func<Vector2, Bullet> Shooting;

    public void Shoot()
    {
        Vector2 spawningPosition = (Vector2)transform.position + _bulletSpawnOffset;
        Bullet bullet = Shooting?.Invoke(spawningPosition);

        bullet.Mover.SetSpeed(_speedX);
    }
}