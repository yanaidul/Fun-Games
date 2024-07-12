using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private QuizGameManagerAdvanced _gameManagerAdvanced;

    public bool stopTimer = false;
    private float _totalDurations;
    private float _countdownTime = 180;

    //Function yang dipanggil untuk memulai timer
    public void StartTimer(float totalDurations)
    {
        _totalDurations = totalDurations;
        _countdownTime = _totalDurations;
        stopTimer = false;
        UpdateTimerText();
    }

    //Function yang dipanggil pada saat gameobject dinyalakan
    private void OnEnable()
    {
        _countdownTime = _totalDurations;
        stopTimer = false;
        UpdateTimerText();
    }

    //Function yang dipanggil untuk mereset timer
    public void OnResetTimer()
    {
        _countdownTime = _totalDurations;
        stopTimer = false;
        UpdateTimerText();
    }

    //Function yang setiap saat untuk melakukan hitungan mundur untuk timer
    void Update()
    {
        if (stopTimer) return;

        if (_countdownTime > 0)
        {
            _countdownTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            Debug.Log("Timer expired!");
            _gameManagerAdvanced.OnDisplayGameOver();
            _countdownTime = 0;
        }
    }

    //Function yang dipanggil untuk mengupdate text timer
    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_countdownTime / 60);
        int seconds = Mathf.FloorToInt(_countdownTime % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        _timerText.SetText(timerString);
    }
}
