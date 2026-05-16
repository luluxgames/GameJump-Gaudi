using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Scenes: MonoBehaviour
{
    public CanvasGroup[] canvasGroups;
    public Image EndPanelImage;
    int currentPanel = 0;

    public float fadeDuration = 2f;

    private void Start()
    {
        for (int i = 0; i < canvasGroups.Length; i++)
        {
            canvasGroups[i].alpha = 0f;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Narrative");
    }

    public void StartGame()
    {
        if (currentPanel < canvasGroups.Length)
        {
            StartCoroutine(FadePanel(canvasGroups[currentPanel]));
            currentPanel++;
        }
        else
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void BackMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator FadePanel(CanvasGroup panel)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            panel.alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);

            yield return null;
        }

        panel.alpha = 1f;
    }
}