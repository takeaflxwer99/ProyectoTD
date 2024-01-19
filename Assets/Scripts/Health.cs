using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Atributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 10;
    // Start is called before the first frame update
    void Start()
    {

    }
    private bool isDestroyed = false;
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;
        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemyGroupManager.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
