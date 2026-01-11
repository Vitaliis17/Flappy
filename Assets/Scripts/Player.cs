using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, ISpawnable, IHasHealth
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Jumper _jumper;

    [SerializeField] private PlayerData _data;

    private Rigidbody2D _rigidbody;

    public Health Health { get; private set; }
    public Shooter Shooter => _shooter;

    public event Action<ISpawnable> Releasing;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        _rigidbody.freezeRotation = true;
    }

    private void OnEnable()
    {
        Health = new(_data.MaxHealthAmount);

        Health.Died += Die;
    }

    private void OnDisable()
        => Health.Died -= Die;

    public void Jump()
        => _jumper.Jump(_rigidbody);

    private void Die()
        => Releasing?.Invoke(this);
}
