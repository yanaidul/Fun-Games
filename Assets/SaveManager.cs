using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private int _currentUnlockedLevel;

    public int CurrentUnlockedLevel => _currentUnlockedLevel;
}
