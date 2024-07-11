using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfLevelBasics : MonoBehaviour
{
    public List<QuizGameManagerBasic> _listOfBasicCategories = new List<QuizGameManagerBasic>();

    public void DeactiveAllCategories()
    {
        foreach (QuizGameManagerBasic list in _listOfBasicCategories)
        {
            list.DeactiveAllLevel();
            list.gameObject.SetActive(false);
        }
    }
}
