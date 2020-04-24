using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Este método se encargad de asignar las teclas que usarán para el movimiento del jugador. En este caso elegí las flechas del teclado para que cada una mueva al jugador en la dirección especificada */
/* Aquí también se asignan las animaciones al movimientod el jugador para que estás vayan de acuerdo al movimeitno o condicionales del jugador. Aqui por ejemplo es hacer que el corra la animación
 * de mover brazos y piernas al mover le personaje par dosimular movimiento.*/

public class Player : MonoBehaviour
{
    
    public float speed = 4f;

    Animator anim;
    Rigidbody2D rb2d; 
    Vector2 mov;

    public GameObject ganasteCanvas;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>(); 

    }

    void Update()
    {

        mov = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
            );

        anim.SetFloat("movX", mov.x);
        anim.SetFloat("movY", mov.y);

    }

    /* Implementación del movimiento y velocidad para mover al personaje */

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime); 
    }

    /* Estas dos condicionales son la sque permiten que el jugador active el evento de restart en el juego, que como ya mencionamos antes, se activa cuando el jugador toca a Albtraum */

    void OnTriggerEnter2D(Collider2D col)
    {
 
        if (col.CompareTag("Enemy"))
        {
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else if (col.CompareTag("Final"))
        {
            ganasteCanvas.GetComponent<Player>();

        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
