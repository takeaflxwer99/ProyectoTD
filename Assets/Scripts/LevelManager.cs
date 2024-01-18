using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{public static LevelManager main;
    public Transform startPoint;
    public Transform[] path;
    public int currency;
    public int health;
    public GameObject MenuPerder;
    public GameObject MenuPausa;

    // Start is called before the first frame update
    private void Awake()
    {
        main = this;
    }
    void Start()
    {
        currency = 150;
        health = 15;

    }
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }
    public bool SpendCurrency(int amount)
    {
        if (amount <= currency) {
            currency -= amount;
            return true;
        }


        else { Debug.Log("No tienes suficientes monedas");
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
            PauseGame();

        }
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
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}

