using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Shooter _shooter;

    private void OnEnable()
    {
        _shooter.Shooting += _spawner.GetBullet;
        _spawner.Disabling += Unsubscribe;
    }

    private void OnDisable()
    {
        _shooter.Shooting -= _spawner.GetBullet;
        _spawner.Disabling -= Unsubscribe;
    }

    private void Unsubscribe()
        => _shooter.Shooting -= _spawner.GetBullet;
}