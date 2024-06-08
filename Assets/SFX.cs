using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : Singleton<SFX>
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _correct;
    [SerializeField] private AudioClip _incorrect;

    protected override void Awake()
    {
        base.Awake();
        if (!TryGetComponent(out AudioSource audioSource)) return;
        _audioSource = audioSource;
    }

    public void OnPlayCorrect()
    {
        _audioSource.PlayOneShot(_correct);
    }

    public void OnPlayIncorrect()
    {
        _audioSource.PlayOneShot(_incorrect);
    }
}
