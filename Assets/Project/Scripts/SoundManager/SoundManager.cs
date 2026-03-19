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
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicSource.generator = clip;
        _musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void PlayAmbience(AudioClip clip)
    {
        _ambienceSource.generator = clip;
        _ambienceSource.Play();
    }

    public void PlayUI(AudioClip clip)
    {
        _uiSource.clip = clip;
        _sfxSource.Play();
    }
}
