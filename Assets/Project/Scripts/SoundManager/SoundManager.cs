using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _sfxSource;
    [SerializeField] AudioSource _ambienceSource;
    [SerializeField] AudioSource _uiSource;
    [SerializeField] AudioSource _singlePlaySource;

    public const float DEFAULT_MUSIC_VOLUME = 0.25f;
    public const float DEFAULT_SFX_VOLUME = 0.5f;
    public const float DEFAULT_AMBIENCE_VOLUME = 0.25f;
    public const float DEFAULT_UI_VOLUME = 0.5f;

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

    public void PlayMusic(AudioClip clip)
    {
        if (_musicSource.clip == clip) return;

        _musicSource.clip = clip;
        _musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        if (_sfxSource.clip == clip) return;

        _sfxSource.clip = clip;
        _sfxSource.Play();
    }

    public void PlayAmbience(AudioClip clip)
    {
        if (_ambienceSource.clip == clip) return;

        _ambienceSource.clip = clip;
        _ambienceSource.Play();
    }

    public void PlayUI(AudioClip clip)
    {
        if (_uiSource.clip == clip) return;

        _uiSource.clip = clip;
        _uiSource.Play();
    }

    public void PlaySingle(AudioClip clip)
    {
        if (_singlePlaySource.clip == clip) return;

        _singlePlaySource.clip = clip;
        _singlePlaySource.Play();
    }

    public void StopMusic()
    {
        _musicSource.Stop();
        _singlePlaySource.clip = null;
    }

    public void StopSFX()
    {
        _sfxSource.Stop();
        _singlePlaySource.clip = null;
    }

    public void StopAmbience()
    {
        _sfxSource.Stop();
        _singlePlaySource.clip = null;
    }

    public void StopSingle()
    {
        _singlePlaySource.Stop();
        _singlePlaySource.clip = null;
    }

    public void StopUI()
    {
        _uiSource.Stop();
        _singlePlaySource.clip = null;
    }

    public void StopAll()
    {
        StopMusic();
        StopSFX();
        StopAmbience();
        StopUI();
        StopSingle();
    }

    public void PlaySfxOneShot(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float value)
    {
        _musicSource.volume = value;
    }

    public void SetSfxVolume(float value)
    {
        _sfxSource.volume = value;
    }

    public void SetAmbienceVolume(float value)
    {
        _ambienceSource.volume = value;
    }

    public void SetUIVolume(float value)
    {
        _uiSource.volume = value;
    }

    public void ResetMusicVolume()
    {
        SetMusicVolume(DEFAULT_MUSIC_VOLUME);
    }

    public void ResetSfxVolume()
    {
        SetSfxVolume(DEFAULT_SFX_VOLUME);
    }

    public void ResetAmbienceVolume()
    {
        SetAmbienceVolume(DEFAULT_AMBIENCE_VOLUME);
    }

    public void ResetUiVolume()
    {
        SetUIVolume(DEFAULT_UI_VOLUME);
    }

    public bool IsSingleSourcePlaying()
    {
        return _singlePlaySource.isPlaying;
    }

    public void PauseAll()
    {
        _musicSource.Pause();
        _sfxSource.Pause();
        _ambienceSource.Pause();
        _singlePlaySource.Pause();
        _uiSource.Pause();
    }

    public void ResumeAll()
    {
        _musicSource.Play();
        _sfxSource.Play();
        _ambienceSource.Play();
        _singlePlaySource.Play();
        _uiSource.Play();
    }
}
