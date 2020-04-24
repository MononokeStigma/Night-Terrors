using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{

    public GameObject target;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false; 
    }

    /* Condicional que permite hacer que si el jugador toca el objeto tipo warp, este lo movera su pocisión a la del segundo warp */
    /* Los warps objetos que sirven como medios de traslado, en este caso son 4 que estan ubicados dos en una entrada y otros dos en la segunda entrada */
    /* Para que estos wraps funcionen, se necesitan crear dos distintos, el de ida y el de vuelta por así decirlo, estos se acomodan en lugares estratégico donde quieres que aparezca tu jugador
     * una vez trasladado*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = target.transform.GetChild(0).transform.position; 
        }
    }

}
