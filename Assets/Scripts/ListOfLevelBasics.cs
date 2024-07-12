using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfLevelBasics : MonoBehaviour
{
    public List<QuizGameManagerBasic> _listOfBasicCategories = new List<QuizGameManagerBasic>();

    //Function yang dipanggil untuk menonaktifkan seluruh game object basic terlebih dahulu sebelum mengaktifkan basic lain agar tidak overlap
    public void DeactiveAllCategories()
    {
        foreach (QuizGameManagerBasic list in _listOfBasicCategories)
        {
            list.DeactiveAllLevel();
            list.gameObject.SetActive(false);
        }
    }
}
