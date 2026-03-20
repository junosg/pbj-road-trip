using System.Collections;
using UnityEngine;

public abstract class SanityEvent: MonoBehaviour
{
    [Tooltip("Delay before event starts in seconds.")]
    [SerializeField] float _eventDelay = 0;

    [Tooltip("Frequency of the event in seconds.")]
    [SerializeField] float _eventRepeatRate = 5;

    [SerializeField] AudioClip _lowSanityClip;
    [SerializeField] AudioClip _highSanityClip;
    [SerializeField] AudioClip _defaultClip;

    public float sanityDecreaseSpeed = 1f;

    private bool _activated;
    public bool Activated { get { return _activated; } set => _activated = value; }

    void Start()
    {
        InvokeRepeating("Activate", _eventDelay, _eventRepeatRate);
    }

    public void Activate()
    {
        if (_activated) return;
        _activated = true;

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
        SoundManager.Instance.PlaySfx(_defaultClip);
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
