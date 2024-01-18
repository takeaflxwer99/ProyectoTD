using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MainMenu : MonoBehaviour
{
    private bool velocidadDoble = false;
    private Button boton;
    private void Start()
    {
        boton = GetComponent<Button>();
        if (boton != null)
        {
            boton.onClick.AddListener(ToggleVelocidad);
        }
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1); }

    public void QuitGame()
    { Application.Quit(); }
    public void QuitLevel()
    { SceneManager.LoadSceneAsync(0); }

    public void ReplayGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

public void OpenLevel1()
{
    SceneManager.LoadScene("Nivel1");
}
    public void OpenLevel2()
    {
        SceneManager.LoadScene("Nivel2");
    }
    public void ToggleVelocidad()
    {

        velocidadDoble = !velocidadDoble;
        Time.timeScale = velocidadDoble ? 2f : 1f;
    }
}



