using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Scenes: MonoBehaviour
{
    public GameObject[] panels;
    public Image EndPanelImage;
    int currentPanel = 0;

    public void Play()
    {
        SceneManager.LoadScene("Narrative");
    }

    public void StartGame()
    {

        if (currentPanel < panels.Length)
        {
            panels[currentPanel].SetActive(true);
            currentPanel++;
        }
        else
        {
            SceneManager.LoadScene("Gameplay");
        }
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