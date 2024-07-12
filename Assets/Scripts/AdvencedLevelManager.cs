using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvencedLevelManager : MonoBehaviour
{
    [SerializeField] private List<Button> _listOfAdvancedLevelsButtons = new();
    [SerializeField] private List<GameObject> _listOfAdvancedLevels= new();
    [SerializeField] private GameObject _canvasAdvancedLevelList;
    [SerializeField] private GameObject _canvasGameSelesai;
    [SerializeField] private int _latestAccessedStage;

    public int LatestAccessedStage => _latestAccessedStage;

    //Function yang dipanggil ketika game object aktif (dalam kasus ini game object UI_Advanced Level Selection)
    private void OnEnable()
    {
        for (int i = 0; i < _listOfAdvancedLevelsButtons.Count; i++)
        {
            if (SaveManager.GetInstance().CurrentUnlockedLevel > i) _listOfAdvancedLevelsButtons[i].interactable = true;
            else _listOfAdvancedLevelsButtons[i].interactable = false;
        }
    }

    //Function yang dipanggil untuk mengakses stage sesuai dengan levelIndex (Bila levelIndex 0, berarti ngakses stage 1)
    public void OnSelectStage(int levelIndex)
    {
        _canvasAdvancedLevelList.SetActive(false);
        _latestAccessedStage = levelIndex + 1;
        TurnOffAllStage();
        _listOfAdvancedLevels[levelIndex].gameObject.SetActive(true);
    }

    //Function yang dipanggil untuk mengakses stage selanjutnya (Function ini dipanggil dari "Next level" button)
    public void OnNextLevel()
    {
        _canvasGameSelesai.SetActive(false);
        _latestAccessedStage += 1;
        if (SaveManager.GetInstance().CurrentUnlockedLevel <= _latestAccessedStage) SaveManager.GetInstance().IncreaseLevel();
        OnSelectStage(_latestAccessedStage - 1);
    }

    //Function yang dipanggil untuk menonaktifan seluruh game object stage terlebih dahulu sebelum mengaktifkan stage lain agar tidak overlap
    public void TurnOffAllStage()
    {
        foreach (GameObject level in _listOfAdvancedLevels)
        {
            level.gameObject.SetActive(false);
        }
    }
}
