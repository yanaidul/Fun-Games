using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private List<GameObject> _healthIconList = new List<GameObject>();
    [SerializeField] private QuizGameManagerAdvanced _quizManagerAdvanced;
    public int _totalHealth = 5;
    public int _howManyHealthInThisLevel = 5;

    private void OnEnable()
    {
        _totalHealth = _howManyHealthInThisLevel;
        foreach (GameObject icon in _healthIconList)
        {
            icon.SetActive(false);
        }
        for (int i = 0; i < _totalHealth; i++)
        {
            _healthIconList[i].SetActive(true);
        }

    }

    public void OnResetHealth()
    {
        _totalHealth = _howManyHealthInThisLevel;
        foreach (GameObject icon in _healthIconList)
        {
            icon.SetActive(false);
        }
        for (int i = 0; i < _totalHealth; i++)
        {
            _healthIconList[i].SetActive(true);
        }
    }

    public void OnDecreaseHealth()
    {
        _totalHealth -= 1;
        _healthIconList[_totalHealth].gameObject.SetActive(false);
    }
}
