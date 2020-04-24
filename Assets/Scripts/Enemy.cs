using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float visionRadius;
    public float attackRadius;
    public float speed;

    GameObject player;

    Vector3 initialPosition;

    Animator anim;
    Rigidbody2D rb2d;

    /*  Este metodo es la etiqueta que hace que Albtraum esté atent a cuando el Gameobject con la etiqueta "Player" Entre en su rango de visión*/
    /*Albtraum no se moverá hasta que dicho gameobject entre en su rango de visión*/

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    /*Todo este método hace los siguiente: 
     1.- Albtraum no se moverá hasta que el objeto "Player" entre en su rango de visión
     2.- Si el objeto permanece dentro de su rango de visión, Albtraum perseguirá al jugador
     3.- Si el jugador se sale del rango de visión de Albtraum, este regresará a la pocisión inicical donde fue pocisionado
     4.- Movimiento y velocidad de Albtraum, así como la implementación de sus animaciones para que cambie de pocisión cuando se mueva de ezquierda a derecha*/

    void Update()
    {

        Vector3 target = initialPosition;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            visionRadius,
            1 << LayerMask.NameToLayer("Default")
        );

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
            }
        }

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        if (target != initialPosition && distance < attackRadius)
        {
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.Play("Enemy_Walk", -1, 0);  
        }
        else
        {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);

            anim.speed = 1;
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.SetBool("walking", true);
        }

        if (target == initialPosition && distance < 0.04f)
        {
            transform.position = initialPosition;
            anim.SetBool("walking", false);
        }

        Debug.DrawLine(transform.position, target, Color.green);
    }

    /*Este método hace que albtraum fije su objetivo en el gameobject que entre ne su rango de visión, en este casso el jugador fue programado con una etiqueta especial para ser el único
     que pueda ser "visto" por Albtraum y de esa manera perseguirlo.*/

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

}
