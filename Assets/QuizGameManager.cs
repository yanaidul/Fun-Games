using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizGameManager : Singleton<QuizGameManager>
{
    [SerializeField] private GameObject _correctPanel;
    [SerializeField] private GameObject _incorrectPanel;

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
}
