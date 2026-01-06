using UnityEngine;

public class Mover
{
    private readonly Rigidbody2D _rigidbody;
    private readonly Transform _transform;

    public Mover(Rigidbody2D rigidbody, Transform transform)
    {
        _rigidbody = rigidbody;
        _transform = transform;
    }

    public void SetSpeed(float speed)
        => _rigidbody.linearVelocityX = speed;

    public void SetPosition(Vector2 position)
        => _transform.position = position;
}