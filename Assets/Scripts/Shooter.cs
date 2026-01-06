using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private Vector2 _bulletSpawnOffset;

    public event Func<Bullet> Shooting;

    public void Shoot()
    {
        Bullet bullet = Shooting?.Invoke();

        bullet.Mover.SetPosition((Vector2)transform.position + _bulletSpawnOffset);
        bullet.Mover.SetSpeed(_speedX);
    }
}