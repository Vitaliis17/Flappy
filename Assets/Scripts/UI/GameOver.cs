using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private EnemyPlanner _enemyPlanner;

    [SerializeField] private Transform _container;

    private void OnEnable()
    {
        _playerSpawner.Released += Activate;
        _playerSpawner.Released += _enemyPlanner.StopSpawning;
        _playerSpawner.Released += _bulletSpawner.ReleaseActiveElements;
        _playerSpawner.Released += _enemySpawner.ReleaseActiveElements;
    }

    private void OnDisable()
    {
        _playerSpawner.Released -= Activate;
        _playerSpawner.Released -= _enemyPlanner.StopSpawning;
        _playerSpawner.Released -= _bulletSpawner.ReleaseActiveElements;
        _playerSpawner.Released -= _enemySpawner.ReleaseActiveElements;
    }

    private void Activate()
        => _container.gameObject.SetActive(true);
}