using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public string scene1;

    void OnTriggerEnter(Collider Treasure)
    {
        SceneManager.LoadScene(scene1);
    }
}
