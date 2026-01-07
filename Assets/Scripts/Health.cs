using System;
using UnityEngine;

[Serializable]
public class Health
{
    [SerializeField, Min(0)] private int _maxValue;

    private readonly int _minValue = 0;

    private int _currentValue;

    public event Action Died;

    public void Initialize()
        => _currentValue = _maxValue;

    public void TakeDamage(int damage)
    {
        _currentValue -= damage;

        if(_currentValue < _minValue)
            _currentValue = _minValue;

        if(IsAlive() == false)
            Died?.Invoke();
    }

    public bool IsAlive()
        => _currentValue > _minValue;
}