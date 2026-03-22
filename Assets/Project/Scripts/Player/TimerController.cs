using System;
using UnityEngine;
using UnityEngine.Events;

public class TimerController : MonoBehaviour
{
    public static TimerController Instance { get; set; }
    public UnityEvent<float> TimerUpdated = new();
    private float _timeCount;

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


    void StartTimer()
    {
        if (GameManager.Instance.IsPaused || GameManager.Instance.IsPaused) return;

        _timeCount += Time.deltaTime;
        TimerUpdated.Invoke(_timeCount);
    }
}
