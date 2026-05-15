using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes: MonoBehaviour
{
    public Image Image;
    public TextMeshProUGUI Text;

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