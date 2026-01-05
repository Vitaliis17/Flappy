using UnityEngine;
using System;

public class ButtonReader : MonoBehaviour
{
    [SerializeField] private KeyCode _keyCode;

    public event Action Pressed;

    private void Update()
    {
        if (Input.GetKeyDown(_keyCode))
            Pressed?.Invoke();
    }
}