using System.Collections;
using UnityEngine;
using System;

public class Timer
{
    public event Action TimeOvered;
    public IEnumerator WaitPeriodically(float time)
    {
        WaitForSeconds waiting = new(time);

        while (true)
        {
            yield return waiting;

            TimeOvered?.Invoke();
        }
    }
}