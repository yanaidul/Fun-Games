using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _countdownTime = 180;
    [SerializeField] private QuizGameManagerAdvanced _gameManagerAdvanced;

    public bool stopTimer = false;

    void Start()
    {
        stopTimer = false;
        UpdateTimerText();
    }

    private void OnEnable()
    {
        _countdownTime = 180;
        stopTimer = false;
        UpdateTimerText();
    }

    public void OnResetTimer()
    {
        _countdownTime = 180;
        stopTimer = false;
        UpdateTimerText();
    }

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

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_countdownTime / 60);
        int seconds = Mathf.FloorToInt(_countdownTime % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        _timerText.SetText(timerString);
    }
}
