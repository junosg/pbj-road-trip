using UnityEngine;

public class SanityManager : MonoBehaviour
{
    public static SanityManager Instance { get; private set; }
    private float _sanity = 100;

    #region GETTERS
    public float Sanity { get { return _sanity; }}
    #endregion 

    #region CONSTANTS
    private const float MAX_SANITY = 100;
    private const float MIN_SANITY = 0;
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
    }

    public void DecreaseSanity(float value)
    {
        _sanity -= value;

        if (_sanity < MIN_SANITY)
        {
            _sanity = MIN_SANITY;
        }
    }
}
