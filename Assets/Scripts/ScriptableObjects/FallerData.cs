using UnityEngine;

[CreateAssetMenu(fileName = "New FallerData", menuName = "Faller")]
public class FallerData : ScriptableObject
{
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    public float MaxRotationZ => _maxRotationZ;
    public float MinRotationZ => _minRotationZ;
}