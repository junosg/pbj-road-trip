using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _sfxSource;
    [SerializeField] AudioSource _ambienceSource;
    [SerializeField] AudioSource _uiSource;

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
        _uiSource.clip = clip;
        _sfxSource.Play();
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
}
