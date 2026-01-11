using UnityEngine;
using System;

public class PlayerSpawner : BaseSpawner<Player>
{
    [SerializeField] private ButtonReader _jumpingReader;
    [SerializeField] private ButtonReader _shootingReader;

    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Vector2 _position;

    public event Action Released;

    public void GetElement()
    {
        Player player = GetElement(_position);
        player.Shooter.Shooting += _bulletSpawner.GetElement;

        _jumpingReader.Pressed += player.Jump;
        _shootingReader.Pressed += player.Shooter.Shoot;
    }

    protected override void Release(ISpawnable element)
    {
        if (element is Player player)
        {
            player.Shooter.Shooting -= _bulletSpawner.GetElement;

            _jumpingReader.Pressed -= player.Jump;
            _shootingReader.Pressed -= player.Shooter.Shoot;
            
            base.Release(player);

            Released?.Invoke();
        }
    }
}