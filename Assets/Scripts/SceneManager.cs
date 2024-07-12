using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //Function yang dipanggil ketika mengeklik button exit game dan lalu keluar dari game
    public void OnExit()
    {
        Application.Quit();
    }
}
