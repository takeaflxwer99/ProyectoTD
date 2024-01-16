using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuniveles : MonoBehaviour
{
    public void OpenLevel()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
