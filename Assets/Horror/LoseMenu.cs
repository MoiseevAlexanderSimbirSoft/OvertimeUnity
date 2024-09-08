using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenu;
   
    public void ShowLoseMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loseMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
    public void Navigate(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void CloseMenu()
    {
        loseMenu.SetActive(false);
    }
}