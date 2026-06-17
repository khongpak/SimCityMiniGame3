using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float tickInterval = 2.0f;
    private float timer;

    public static event Action OnTick;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= tickInterval)
        {
            timer = 0f;
            OnTick?.Invoke();
        }
    }
}
