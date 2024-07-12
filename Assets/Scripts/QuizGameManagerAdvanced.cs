using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizGameManagerAdvanced : Singleton<QuizGameManagerAdvanced>
{
    private int _currentSoal = 0;
    [SerializeField] private List<Soal> _listSoal = new List<Soal>();
    [SerializeField] private GameObject _permainanSelesaiPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private GameObject _correctPanel;
    [SerializeField] private GameObject _incorrectPanel;
    [SerializeField] private Health _health;
    [SerializeField] private Timer _timer;
    [SerializeField] private float _totalDuration;
    [SerializeField] private bool _isThisFinalLevel;

    //Function yang dipanggil pada saat gameobject dinyalakan
    private void OnEnable()
    {
        _currentSoal = 0;
        DeactiveAllSoal();
        _timer.StartTimer(_totalDuration);
        _listSoal[_currentSoal].gameObject.SetActive(true);
    }

    //Function yang dipanggil untuk reset soal dari awal
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

    //Function yang dipanggil untuk menampilkan tampilan game over
    public void OnDisplayGameOver()
    {
        _timer.stopTimer = true;
        _gameOverPanel.SetActive(true);
    }

    //Function yang dipanggil untuk menampilkan tampilan correct panel
    public void OnDisplayCorrectPanel()
    {
        SFX.GetInstance().OnPlayCorrect();
        _correctPanel.SetActive(true);
        StartCoroutine(TurnPanelInactiveDelay());
    }

    //Function yang dipanggil untuk menampilkan tampilan incorrect
    public void OnDisplayIncorrectPanel()
    {
        SFX.GetInstance().OnPlayIncorrect();
        _incorrectPanel.SetActive(true);
        StartCoroutine(TurnPanelInactiveDelay());
    }

    //Function yang dipanggil untuk menonaktifkan correctpanel/incorrect panel setelah 1 detik
    IEnumerator TurnPanelInactiveDelay()
    {
        yield return new WaitForSeconds(1f);
        _correctPanel.SetActive(false);
        _incorrectPanel.SetActive(false);
    }

    //Function yang dipanggil untuk memanggil soal selanjutnya, dan bila sudah soal terakhir, maka memanggil permainan selesai panel
    public void OnNextSoal()
    {
        _currentSoal++;
        if (_currentSoal == 5)
        {
            if(_isThisFinalLevel) _nextLevelButton.gameObject.SetActive(false);
            else SaveManager.GetInstance().IncreaseLevel();

            _permainanSelesaiPanel.SetActive(true);
        }
        else
        {
            _correctPanel.gameObject.SetActive(true);
            StartCoroutine(OnDelayChangeSoal());
        }
    }

    //Function yang dipanggil untuk menonaktifkan semua soal gameobject sebelum mengaktifkan soal lain agar tidak overlap
    public void DeactiveAllSoal()
    {
        foreach (Soal soal in _listSoal)
        {
            soal.gameObject.SetActive(false);
        }
    }

    //Function yang dipanggil untuk mengganti soal setelah delay 1 detik
    IEnumerator OnDelayChangeSoal()
    {
        yield return new WaitForSeconds(1f);
        _correctPanel.gameObject.SetActive(false);
        DeactiveAllSoal();
        _listSoal[_currentSoal].gameObject.SetActive(true);
    }

}
