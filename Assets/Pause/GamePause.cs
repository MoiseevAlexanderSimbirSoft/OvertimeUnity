using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePause : MonoBehaviour
{
    public TextMeshProUGUI pauseText;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseText.text = "Пауза!\nЧтобы снять нажмите на Esc";
        pauseText.gameObject.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseText.gameObject.SetActive(false);
    }
}
