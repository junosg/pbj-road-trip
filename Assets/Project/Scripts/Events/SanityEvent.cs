using System.Collections;
using UnityEngine;

public static class SanityEventData
{
    public static int ActivatedCount = 0;
}

public abstract class SanityEvent: MonoBehaviour
{
    [Tooltip("Delay before event starts in seconds.")]
    [SerializeField] float _eventDelay = 0;

    [Tooltip("Frequency of the event in seconds.")]
    [SerializeField] float _eventRepeatRate = 5;
    [Range(0, 1)]
    [SerializeField] float _eventProbability = 1;

    [SerializeField] AudioClip _lowSanityClip;
    [SerializeField] AudioClip _highSanityClip;
    [SerializeField] AudioClip _defaultClip;

    public float sanityDecreaseSpeed = 1f;

    private bool _activated;
    public bool Activated { get { return _activated; } }

    private float _timeStarted;
    public float TimeDuration
    {
        get
        {
            return Time.deltaTime - _timeStarted;
        }
    }

    void Start()
    {
        InvokeRepeating("Activate", _eventDelay, _eventRepeatRate);
    }

    public void Activate()
    {
        if (_activated) return;
        if (Random.Range(0, 1) > _eventProbability) return;

        _activated = true;
        SanityEventData.ActivatedCount += 1;

        if (SanityManager.Instance.Sanity < SanityManager.LOW_SANITY_THRESHOLD)
        {
            SoundManager.Instance.PlaySfx(_lowSanityClip);
        } else
        {
            SoundManager.Instance.PlaySfx(_highSanityClip);
        }

        OnActivate();
    }

    public void Deactivate()
    {
        if (!_activated) return;
        _activated = false;
        SanityEventData.ActivatedCount -= 1;

        if (SanityEventData.ActivatedCount <= 0) SoundManager.Instance.PlaySfx(_defaultClip);
        OnDeactivate();
    }

    public abstract void OnActivate();
    public abstract void OnDeactivate();

    public bool IsOnCamera()
    {
        Vector3 viewPosition = Camera.main.WorldToViewportPoint(transform.GetChild(0).transform.position);

        bool inFront = viewPosition.z > 0;
        bool onScreen = viewPosition.x >= 0 && viewPosition.x <= 1 && viewPosition.y >= 0 && viewPosition.y <= 1;

        return inFront && onScreen;
    }
}
