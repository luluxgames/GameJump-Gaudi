using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes: MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Narrative");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}