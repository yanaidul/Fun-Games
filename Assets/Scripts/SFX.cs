using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : Singleton<SFX>
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _correct;
    [SerializeField] private AudioClip _incorrect;

    //Function yang dipanggil pertama kali pada saat game object aktif
    protected override void Awake()
    {
        base.Awake();
        if (!TryGetComponent(out AudioSource audioSource)) return;
        _audioSource = audioSource;
    }

    //Function yang dipanggil untuk mengaktifkan correct SFX
    public void OnPlayCorrect()
    {
        _audioSource.PlayOneShot(_correct);
    }

    //Function yang di panggil untuk mengaktifkan incorrect SFX
    public void OnPlayIncorrect()
    {
        _audioSource.PlayOneShot(_incorrect);
    }
}
