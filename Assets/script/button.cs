using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public void ContinueGame()
    // {
    //     // Load saved game data
    //     GameData savedData = LoadGameData();

    //     // Load appropriate scene
    //     SceneManager.LoadScene(savedData.sceneName);

    //     // Restore player state
       
    // }

    public void NewGame()
    {
        // Reset game data (if needed)

        // Load initial scene
        SceneManager.LoadScene("gameplay");

        // Initialize player state
       
    }

        public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

}
