using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EntitiesData/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField, Min(0)] private int _maxHealthAmount;
    [SerializeField, Min(0)] private float _shootingPeriodicity;

    public int MaxHealthAmount => _maxHealthAmount;
    public float ShootingPeriodicity => _shootingPeriodicity;
}