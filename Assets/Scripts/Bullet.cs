using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

    public event Action Releasing;

    public Mover Mover { get; private set; }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.gravityScale = 0f;

        Mover = new(_rigidbody, transform);
    }
}