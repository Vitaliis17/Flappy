using System;
using UnityEngine;

[Serializable]
public class Attacker
{
    [SerializeField, Min(0)] private int _damage;

    public void Attack(Health health)
        => health.TakeDamage(_damage);
}