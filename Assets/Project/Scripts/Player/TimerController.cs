using System;
using UnityEngine;
using UnityEngine.Events;

public class TimerController : MonoBehaviour
{
    public static TimerController Instance { get; set; }
    public UnityEvent<float> TimerUpdated = new();

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } 
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        StartTimer();
    }


    public void StartTimer()
    {
        TimerUpdated.Invoke(1);
    }


}
