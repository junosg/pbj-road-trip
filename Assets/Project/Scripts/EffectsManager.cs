using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EffectsManager : MonoBehaviour
{
    private Volume _volume;
    private LensDistortion _lensDistortionComponent;
    private Vignette _vignette;
    private ChromaticAberration _aberration;

    public static EffectsManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _volume = GetComponent<Volume>();
        _volume.profile.TryGet(out _lensDistortionComponent);
        _volume.profile.TryGet(out _vignette);
        _volume.profile.TryGet(out _aberration);
    }

    public void SetDistortionIntensity(float value)
    {
        _lensDistortionComponent.intensity.value = value;
    }

    public void SetVignetteIntensity(float value)
    {
        _vignette.intensity.value = value;
    }

    public void SetAberration(float value)
    {
        _aberration.intensity.value = value;
    }
}
