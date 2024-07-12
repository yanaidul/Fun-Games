using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private int _currentUnlockedLevel;

    public int CurrentUnlockedLevel => _currentUnlockedLevel;

    //Function yang dipanggil untuk menaikkan current unlocked level di advanced level list
    public void IncreaseLevel()
    {
        _currentUnlockedLevel++;
    }
}
