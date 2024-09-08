using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinMenu : MonoBehaviour
{
   public GameObject winMenu;
   
   public void ShowWinMenu()
   {
      winMenu.SetActive(true);
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
      winMenu.SetActive(false);
   }
}
