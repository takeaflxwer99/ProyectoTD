using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    { SceneManager.LoadSceneAsync(1); }

    public void QuitGame()
    { Application.Quit(); }
    public void QuitLevel()
    { SceneManager.LoadSceneAsync(0); }

    public void ReplayGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
}

    
