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

    // Start is called before the first frame update
    private void Awake()
    {
        main = this;
    }
    void Start()
    {
        currency = 100;
        health = 150;

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

    void LoseHealth(Collider other)
        {
            // Verificar si el objeto que entró en el trigger es un enemigo 
            if (other.CompareTag("Enemy"))
            {
                // Destruir el enemigo
                Destroy(other.gameObject);
                health--;

                if (health <= 0)
                {
                    Debug.Log("Game Over");
                   
                }
            }
        }
    }
