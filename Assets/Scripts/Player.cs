using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, ISpawnable, IHealthable
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Jumper _jumper;

    [SerializeField] private PlayerData _data;

    private Health _health;
    private Rigidbody2D _rigidbody;

    public Health Health => _health;
    public Shooter Shooter => _shooter;

    public event Action<ISpawnable> Releasing;

    private void Awake()
    {
        _health = new(_data.MaxHealthAmount);

        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        _rigidbody.freezeRotation = true;
    }

    private void OnEnable()
        => _health.Died += Die;

    private void OnDisable()
        => _health.Died -= Die;

    public void Jump()
        => _jumper.Jump(_rigidbody);

    private void Die()
        => Releasing?.Invoke(this);
}
