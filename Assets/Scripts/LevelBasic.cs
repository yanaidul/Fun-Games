using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBasic : MonoBehaviour
{
    [SerializeField] private bool _isDone = false;

    public bool IsDone => _isDone;

    //Function yang di pnaggil untuk ngaish penanda bahwa level ini sudah selesai
    public void SetIsDoneValue(bool value)
    {
        _isDone = value;
    }
}
