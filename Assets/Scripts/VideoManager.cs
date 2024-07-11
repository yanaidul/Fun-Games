using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    private void Start()
    {
        _videoPlayer.Stop();
    }

    private void OnEnable()
    {
        _videoPlayer.Play();
    }

    private void OnDisable()
    {
        _videoPlayer.Stop();
    }
}
