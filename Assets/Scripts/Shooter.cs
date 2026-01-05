using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Vector2 _speed;

    public event Func<Bullet> Shooting;

    public void Shoot()
    {
        Bullet bullet = Shooting?.Invoke();
        
        if(bullet.TryGetComponent(out Rigidbody2D rigidbody))
            rigidbody.AddForce(_speed);
    }
}