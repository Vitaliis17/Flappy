using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyPlanner : MonoBehaviour
{
    [SerializeField] private WavePlanner[] _waves;

    private List<Enemy> _enemies;
    private Coroutine _coroutine;

    public event Func<Vector2, Enemy> Spawning;

    private void Awake()
        => _enemies = new List<Enemy>();

    private void OnDisable()
        => StopSpawning();

    public void StopSpawning()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void StartSpawning()
        => _coroutine = StartCoroutine(SpawnAll());

    private IEnumerator SpawnAll()
    {
        for (int i = 0; i < _waves.Length; i++)
        {
            Spawn(i);

            yield return RemoveInactiveEnemies();
        }
    }

    private IEnumerator RemoveInactiveEnemies(int secondFrameAmount = 20)
    {
        const float Second = 1;

        float frameTime = Second / secondFrameAmount;

        WaitForSeconds waiting = new(frameTime);

        while(_enemies.Count > 0)
        {
            _enemies.RemoveAll(enemy => enemy.gameObject.activeSelf == false);

            yield return waiting;
        }
    }

    private void Spawn(int waveIndex)
    {
        Enemy enemy;
        int enemyAmount = _waves[waveIndex].EnemyCount;

        for (int i = 0; i < enemyAmount; i++)
        {
            enemy = Spawning?.Invoke(_waves[waveIndex][i]);
            _enemies.Add(enemy);
        }
    }
}