using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "EntitiesData/Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField, Min(0)] private int _maxHealthAmount;

    public int MaxHealthAmount => _maxHealthAmount;
}