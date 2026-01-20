using UnityEngine;

public class Faller : MonoBehaviour
{
    [SerializeField] private FallerData _data;
    [SerializeField] private float _speed;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _minRotation = Quaternion.Euler(Vector3.forward * _data.MinRotationZ);
        _maxRotation = Quaternion.Euler(Vector3.forward * _data.MaxRotationZ);
    }

    private void FixedUpdate()
        => transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _speed * Time.fixedDeltaTime);

    public void SetMaxRotation()
        => transform.rotation = _maxRotation;
}