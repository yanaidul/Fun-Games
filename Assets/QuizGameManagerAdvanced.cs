using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizGameManagerAdvanced : Singleton<QuizGameManagerAdvanced>
{
    private int _currentSoal = 0;
    [SerializeField] private List<Soal> _listSoal = new List<Soal>();
    [SerializeField] private GameObject _permainanSelesaiPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _correctPanel;
    [SerializeField] private GameObject _incorrectPanel;
    [SerializeField] private Health _health;
    [SerializeField] private Timer _timer;
    [SerializeField] private float _totalDuration;

    private void OnEnable()
    {
        _currentSoal = 0;
        DeactiveAllSoal();
        _timer.StartTimer(_totalDuration);
        _listSoal[_currentSoal].gameObject.SetActive(true);
    }

    public void OnResetSoal()
    {
        _currentSoal = 0;
        DeactiveAllSoal();
        _listSoal[_currentSoal].gameObject.SetActive(true);
        foreach (var soal in _listSoal)
        {
            soal.OnResetGambar();
        }
        _health.OnResetHealth();
        _timer.OnResetTimer();
    }

    public void OnDisplayGameOver()
    {
        _timer.stopTimer = true;
        _gameOverPanel.SetActive(true);
    }

    public void OnDisplayCorrectPanel()
    {
        _correctPanel.SetActive(true);
        StartCoroutine(TurnPanelInactiveDelay());
    }

    public void OnDisplayIncorrectPanel()
    {
        _incorrectPanel.SetActive(true);
        StartCoroutine(TurnPanelInactiveDelay());
    }

    IEnumerator TurnPanelInactiveDelay()
    {
        yield return new WaitForSeconds(1f);
        _correctPanel.SetActive(false);
        _incorrectPanel.SetActive(false);
    }

    public void OnNextSoal()
    {
        _currentSoal++;
        if (_currentSoal == 5)
        {
            _permainanSelesaiPanel.SetActive(true);
        }
        else
        {
            _correctPanel.gameObject.SetActive(true);
            StartCoroutine(OnDelayChangeSoal());
        }
    }

    public void DeactiveAllSoal()
    {
        foreach (Soal soal in _listSoal)
        {
            soal.gameObject.SetActive(false);
        }
    }

    IEnumerator OnDelayChangeSoal()
    {
        yield return new WaitForSeconds(1f);
        _correctPanel.gameObject.SetActive(false);
        DeactiveAllSoal();
        _listSoal[_currentSoal].gameObject.SetActive(true);
    }

}
