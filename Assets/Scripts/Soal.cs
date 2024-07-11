using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soal : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gambarList = new List<GameObject>();
    [SerializeField] private int _currentGambar = 0;
    [SerializeField] private QuizGameManagerAdvanced _quizGameManagerAdvanced;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _currentGambar = 0;
        DeactiveAllGambar();
        _gambarList[_currentGambar].SetActive(true);
    }

    public void OnResetGambar()
    {
        _currentGambar = 0;
        DeactiveAllGambar();
        _gambarList[_currentGambar].SetActive(true);
    }

    public void OnSubmitJawabanSalah()
    {
        SFX.GetInstance().OnPlayIncorrect();
        _health.OnDecreaseHealth();
        if (_health._totalHealth == 0) _quizGameManagerAdvanced.OnDisplayGameOver();
    }

    public void OnSubmitJawabanBenar()
    {
        _currentGambar += 1;
        SFX.GetInstance().OnPlayCorrect();
        if (_currentGambar >= 3)
        {
            _quizGameManagerAdvanced.OnNextSoal();
        }
        else
        {
            DeactiveAllGambar();
            _gambarList[_currentGambar].gameObject.SetActive(true);
        }

    }

    public void DeactiveAllGambar()
    {
        foreach (GameObject gambar in _gambarList)
        {
            gambar.SetActive(false);
        }
    }


}
