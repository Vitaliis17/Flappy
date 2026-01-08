using UnityEngine;

public class BulletSpawnController : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private Shooter _shooter;

    private void OnEnable()
    {
        _shooter.Shooting += _spawner.GetElement;
        _spawner.Disabling += Unsubscribe;
    }

    private void OnDisable()
    {
        _shooter.Shooting -= _spawner.GetElement;
        _spawner.Disabling -= Unsubscribe;
    }

    private void Unsubscribe()
        => _shooter.Shooting -= _spawner.GetElement;
}