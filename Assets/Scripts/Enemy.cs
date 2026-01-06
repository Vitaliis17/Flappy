using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
        => _health.Initialize();
}