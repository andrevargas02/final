using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void PlayGame1()
    {
        SceneManager.LoadSceneAsync(1);
    }

public void QuitGame1(){
    Application.Quit();
}
 
}
 