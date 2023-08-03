using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject MenuPause;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }
}
