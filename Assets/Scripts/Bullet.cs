using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.gravityScale = 0f;
    }

    public void SetSpeed(float speed)
        => _rigidbody.linearVelocityX = speed;

    public void SetPosition(Vector2 position)
        => transform.position = position;
}