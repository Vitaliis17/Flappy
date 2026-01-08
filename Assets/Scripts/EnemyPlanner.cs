using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyPlanner : MonoBehaviour
{
    [SerializeField] private WavePlanner[] _waves;

    private List<Enemy> _enemies;
    private Coroutine _coroutine;

    private bool _waveDestroyed;

    public event Func<Vector2, Enemy> Spawning;

    private void OnDisable()
        => StopCoroutine(_coroutine);

    private void Start()
    {
        _enemies = new List<Enemy>();
        _coroutine = StartCoroutine(SpawnAll());

        _waveDestroyed = true;
    }

    private void FixedUpdate()
    {
        _enemies.RemoveAll(enemy => enemy.gameObject.activeSelf == false);
        _waveDestroyed = _enemies.Count == 0;
    }

    private IEnumerator SpawnAll()
    {
        WaitUntil waiting = new(() => _waveDestroyed);

        for(int i = 0; i < _waves.Length; i++)
        {
            Spawn(i);

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

        _waveDestroyed = false;
    }
}