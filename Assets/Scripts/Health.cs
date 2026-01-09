using System;

public class Health
{
    private readonly int _minValue = 0;
    private readonly int _maxValue;

    private int _currentValue;

    public event Action Died;

    public Health(int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = _maxValue;
    }

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