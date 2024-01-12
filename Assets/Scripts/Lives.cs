using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public int lives = 100;
    public TextMeshProUGUI txt_lives;
   
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entr� en el trigger es un enemigo 
        if (other.CompareTag("Enemy"))
        {
            // Destruir el enemigo 
            Destroy(other.gameObject);
            lives--;
            txt_lives.text = lives.ToString();
        }
        if (lives <=0)
        { Debug.Log("Game Over"); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
