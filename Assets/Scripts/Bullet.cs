using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, ISpawnable
{
    [SerializeField] private Attacker _attacker;

    private Rigidbody2D _rigidbody;

    public event Action<ISpawnable> Releasing;

    public Mover Mover { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.gravityScale = 0f;

        Mover = new(_rigidbody);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out IHasHealth healthable))
            _attacker.Attack(healthable.Health);

        Releasing?.Invoke(this);
    }
}