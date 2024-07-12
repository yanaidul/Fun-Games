using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizGameManagerBasic : Singleton<QuizGameManagerBasic>
{
    private int _currentLevel = 0;
    private int _random = 0;
    [SerializeField] private List<LevelBasic> _listLevel = new List<LevelBasic>();
    [SerializeField] private GameObject _permainanSelesaiPanel;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private GameObject _correctPanel;
    [SerializeField] private GameObject _incorrectPanel;

    //Function yang dipanggil ketika game object aktif 
    private void OnEnable()
    {
        _currentLevel = 0;
        foreach (LevelBasic level in _listLevel)
        {
            level.SetIsDoneValue(false);
        }
        DeactiveAllLevel();
        OnDisplayRandomLevel();
    }

    //Function yang dipanggil untuk menampilkan correct panel
    public void OnDisplayCorrectPanel()
    {
        SFX.GetInstance().OnPlayCorrect();
        _correctPanel.SetActive(true);
        StartCoroutine(TurnPanelInactiveDelay(true));
    }

    //Function yang dipanggil untuk menampilkan incorrect panel
    public void OnDisplayIncorrectPanel()
    {
        SFX.GetInstance().OnPlayIncorrect();
        _incorrectPanel.SetActive(true);
        StartCoroutine(TurnPanelInactiveDelay(false));
    }

    //Function yang dipanggil untuk lanjut ke level selanjutnya
    public void OnNextLevel()
    {
        _currentLevel++;
        if (_currentLevel == 10)
        {
            _nextLevelButton.gameObject.SetActive(false);

            _permainanSelesaiPanel.SetActive(true);
        }
        else
        {
            _listLevel[_random].SetIsDoneValue(true);
            StartCoroutine(OnDelayChangeLevel());
        }
    }

    //Function yang dipanggil untuk menampilkan level secara random
    private void OnDisplayRandomLevel()
    {
        _random = Random.Range(0, _listLevel.Count);
        _listLevel[_random].gameObject.SetActive(true);
        while (_listLevel[_random].IsDone)
        {
            _listLevel[_random].gameObject.SetActive(false);
            _random = Random.Range(0, _listLevel.Count);
            _listLevel[_random].gameObject.SetActive(true);
        }
    }

    //Function yang dipanggil untuk menonaktifkan panel correct/incorrect setelah beberapa detik
    IEnumerator TurnPanelInactiveDelay(bool isCorrect)
    {
        yield return new WaitForSeconds(1f);
        _correctPanel.SetActive(false);
        _incorrectPanel.SetActive(false);
        if (isCorrect) OnNextLevel();
    }

    //Function yang dipanggil untuk menonaktifan seluruh game object level terlebih dahulu sebelum mengaktifkan level lain agar tidak overlap
    public void DeactiveAllLevel()
    {
        foreach (LevelBasic level in _listLevel)
        {
            level.gameObject.SetActive(false);
        }
    }

    //Function yang dipanggil untuk mengganti level secara random setelah 1 detik
    IEnumerator OnDelayChangeLevel()
    {
        yield return new WaitForSeconds(1f);
        DeactiveAllLevel();
        OnDisplayRandomLevel();
    }
}
