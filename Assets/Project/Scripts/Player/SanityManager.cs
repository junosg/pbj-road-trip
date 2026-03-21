using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SanityManager : MonoBehaviour
{
    public static SanityManager Instance { get; private set; }
    private float _sanity = 100;
    
    [Header("BGM Clips")]
    [SerializeField] AudioClip _highSanityBGM;
    [SerializeField] AudioClip _lowSanityBGM;
    [SerializeField] AudioClip _highSanityAmbience;
    [SerializeField] AudioClip _lowSanityAmbience;

    #region GETTERS
    public float Sanity { get { return _sanity; }}
    #endregion 

    #region CONSTANTS
    public const float MAX_SANITY = 100;
    public const float MIN_SANITY = 0;
    public const float LOW_SANITY_THRESHOLD = 40;
    #endregion

    #region EVENTS
    public UnityEvent<float> SanityUpdated = new();
    #endregion

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    public void IncreaseSanity(float value)
    {
        _sanity += value;

        if (_sanity > MAX_SANITY)
        {
            _sanity = MAX_SANITY;
        }

        if (_sanity > LOW_SANITY_THRESHOLD)
        {
            SoundManager.Instance.PlayMusic(_highSanityBGM);
        }

        SanityUpdated.Invoke(_sanity);
    }

    public void DecreaseSanity(float value)
    {
        _sanity -= value;

        if (_sanity < MIN_SANITY)
        {
            _sanity = MIN_SANITY;
        }

        if (_sanity < LOW_SANITY_THRESHOLD)
        {
            SoundManager.Instance.PlayMusic(_lowSanityBGM);
        }

        SanityUpdated.Invoke(_sanity);
    }

    public void PlayHighSanityBGM()
    {
        SoundManager.Instance.PlayMusic(_highSanityBGM);
    }

    public void PlayLowSanityBGM()
    {
        SoundManager.Instance.PlayMusic(_lowSanityBGM);
    }

    public void PlayHighSanityAmbience()
    {
        SoundManager.Instance.PlayMusic(_highSanityAmbience);
    }

    public void PlayLowSanityAmbience()
    {
        SoundManager.Instance.PlayMusic(_lowSanityAmbience);
    }
}
