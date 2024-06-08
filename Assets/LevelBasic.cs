using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBasic : MonoBehaviour
{
    [SerializeField] private bool _isDone = false;

    public bool IsDone => _isDone;

    public void SetIsDoneValue(bool value)
    {
        _isDone = value;
    }
}
