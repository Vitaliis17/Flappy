using UnityEngine;
using System;

public class ButtonReader : MonoBehaviour
{
    [SerializeField] private KeyCode[] _keyCodes;

    public event Action Pressed;

    private void Update()
    {
        if (IsKeyDown())
            Pressed?.Invoke();
    }

    private bool IsKeyDown()
    {
        bool isKeyDown = false;

        foreach (KeyCode key in _keyCodes)
        {
            if (Input.GetKeyDown(key))
            {
                isKeyDown = true;
                break;
            }
        }

        return isKeyDown;
    }
}