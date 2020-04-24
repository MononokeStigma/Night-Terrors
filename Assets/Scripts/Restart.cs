using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Este método hace que si se cumplen las condiciones necesarias, se reinicie el juego */
/* La única condición para el reinicio es que el jugador sea tocado por el enemigo "Albtraum" */

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
