using UnityEngine;

public class Mover
{
    private readonly Rigidbody2D _rigidbody;

    public Mover(Rigidbody2D rigidbody)
        => _rigidbody = rigidbody;

    public void SetSpeed(float speed)
        => _rigidbody.linearVelocityX = speed;
}