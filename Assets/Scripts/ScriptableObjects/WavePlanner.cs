using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
public class WavePlanner : ScriptableObject
{
    [SerializeField] private Vector2[] _enemyPositions;

    public Vector2 this[int index] => _enemyPositions[index];
    public int EnemyCount => _enemyPositions.Length;
}