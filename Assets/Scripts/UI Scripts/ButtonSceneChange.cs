using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChange : MonoBehaviour
{

    public string Scene;

    public void changeScene()
    {
        SceneManager.LoadScene(Scene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}


