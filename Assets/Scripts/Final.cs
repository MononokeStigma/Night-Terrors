using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Se supone que esto muestra un mensaje y finaliza el juego cuando el jugador toca a los niños llorando, pero por alguna razón no funciona. No se porque... */

public class Final : MonoBehaviour
{
    public GameObject ganasteCanvas;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            ganasteCanvas.GetComponent<Canvas>().enabled = true; 
    }
}
