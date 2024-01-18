using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocidadx2 : MonoBehaviour
{
    private bool velocidadDoble = false;
    public Button boton;
    // Start is called before the first frame update
void Start()
    {
        boton = GetComponent<Button>();
        if (boton != null)
        {
            boton.onClick.AddListener(ToggleVelocidad);
        }
    }
    public void ToggleVelocidad()
    {

        velocidadDoble = !velocidadDoble;

        Time.timeScale = velocidadDoble ? 2f : 1f;

        if (!velocidadDoble)
        {
            boton.interactable = !boton.interactable;
        }
    }
}
