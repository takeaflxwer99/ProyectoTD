

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public Transform startPoint;
    public Transform[] path;
    public int currency;
    public int health;
    public GameObject MenuPerder;
    public GameObject MenuPausa;
    public GameObject victoryMenu;

    public AudioSource gameMusic;
    public AudioSource gameOverSound;
    public AudioSource victorySound;


    private bool isPaused = false;



    // Start is called before the first frame update
    private void Awake()
    {
        main = this;
    }
    void Start()
    {
        currency = 150;
        health = 15;
        EnemyGroupManager.onLastWaveDestroyed.AddListener(ShowVictoryMenu);
        gameMusic.Play();
    }
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }
    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }


        else
        {
            Debug.Log("No tienes suficientes monedas");
            return false;
        }
    }

    public void LoseHealth()
    {
        health--;

        if (health <= 0)
        {
            Debug.Log("Game Over");
            ShowGameOverMenu();
        }
    }

    private void ShowGameOverMenu()
    {
        if (MenuPerder != null)
        {
            MenuPerder.SetActive(true);

            if (gameOverSound != null)
            {
                gameOverSound.Play();
            }

            PauseGame();
        }
    }

    void ShowVictoryMenu()
    {
        // Activa el menú de victoria cuando se dispare el evento
        victoryMenu.SetActive(true);


        if (victorySound != null)
        {
            victorySound.Play();
        }

        // Pausar el juego cuando se muestra el menú de victoria
        PauseGame();
    }


    private void ShowPauseMenu()
    {
        if (MenuPausa != null)
        {
            MenuPausa.SetActive(true);
            
            PauseGame();

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            LoseHealth();
        }
    }

    
    private void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;

            // Pausar la música
            if (gameMusic != null && gameMusic.isPlaying)
            {
                gameMusic.Pause();
                Debug.Log("Game music paused.");
            }
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;

            // Resumir la música solo si el juego no está en pausa
            if (gameMusic != null && !gameMusic.isPlaying)
            {
                gameMusic.UnPause();
            }
        }
    }
}


