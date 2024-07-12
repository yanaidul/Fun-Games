using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    //Function yang dipanggil pada saat gameobject dinyalakan
    private void Start()
    {
        _videoPlayer.Stop();
    }

    //Function yang dipanggil pada saat gameobject dinyalakan
    private void OnEnable()
    {
        _videoPlayer.Play();
    }

    //Function yang dipanggil pada saat gameobject dinonaktifkan
    private void OnDisable()
    {
        _videoPlayer.Stop();
    }
}
