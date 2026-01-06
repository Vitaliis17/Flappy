using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private ButtonReader _jumpingReader;
    [SerializeField] private ButtonReader _shootingReader;

    [SerializeField] private Shooter _shooter;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Health _health;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _health.Initialize();

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _jumpingReader.Pressed += Jump;
        _shootingReader.Pressed += Shoot;
    }

    private void OnDisable()
    {
        _jumpingReader.Pressed -= Jump;
        _jumpingReader.Pressed -= Shoot;
    }

    private void Jump()
        => _jumper.Jump(_rigidbody);

    private void Shoot()
        => _shooter.Shoot();
}
