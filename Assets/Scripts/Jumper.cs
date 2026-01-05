using System;
using UnityEngine;

[Serializable]
public class Jumper
{
    [SerializeField] private float _force;

    public void Jump(Rigidbody2D rigidbody)
        => rigidbody.linearVelocityY = _force;
}