using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonmanajer : MonoBehaviour
{
    // Start is called before the first frame update
    

    public void Basicmenu(){
         SceneManager.LoadScene("menubasic");
    }
    public void Advancemenu(){
         SceneManager.LoadScene("Advance");
    }
    public void Backhome(){
         SceneManager.LoadScene("Main");
    }
}
