using UnityEngine;
using System;

public class EnemyPlanner : MonoBehaviour
{
    [SerializeField] private WavePlanner _wave;

    public event Func<Vector2, Enemy> Spawning;

    private void Start()
    {
        int enemyAmount = _wave.EnemyCount;

        for(int i = 0; i < enemyAmount; i++)
            Spawning?.Invoke(_wave[i]);
    }
}