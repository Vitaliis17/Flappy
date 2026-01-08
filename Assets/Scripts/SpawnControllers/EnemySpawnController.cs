using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private EnemyPlanner _planner;

    private void OnEnable()
    {
        _planner.Spawning += _spawner.GetElement;
        _spawner.Disabling += Unsubscribe;
    }

    private void OnDisable()
    {
        _planner.Spawning -= _spawner.GetElement;
        _spawner.Disabling -= Unsubscribe;
    }

    private void Unsubscribe()
        => _planner.Spawning -= _spawner.GetElement;
}