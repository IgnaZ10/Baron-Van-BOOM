using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // La velocidad de movimiento del personaje
    private bool isFrozen = false; // Variable que indica si el personaje est� congelado
    private Vector3 frozenDirection; // Variable que almacena la direcci�n en la que se mueve el personaje antes de congelarse

    // M�todo que se llama una vez por cuadro
    private void Update()
    {
        // Solo permitir el movimiento si el personaje no est� congelado
        if (!isFrozen)
        {
            // Obtener la entrada de movimiento horizontal y vertical
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Crear un vector de movimiento en funci�n de la entrada del jugador
            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

            // Normalizar el vector de movimiento para que no se mueva m�s r�pido en diagonal
            movement.Normalize();

            // Multiplicar el vector de movimiento por la velocidad de movimiento y por el tiempo transcurrido desde el �ltimo cuadro
            movement *= moveSpeed * Time.deltaTime;

            // Mover el personaje en funci�n del vector de movimiento
            transform.Translate(movement, Space.World);
        }
    }

    // M�todo que se llama cuando el personaje colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colision� tiene un BoxCollider
        if (collision.collider is BoxCollider)
        {
            // Congelar al personaje en la direcci�n en la que se estaba moviendo
            isFrozen = true;
            frozenDirection = transform.forward;
        }
    }

    // M�todo que se llama cuando el personaje deja de colisionar con otro objeto
    private void OnCollisionExit(Collision collision)
    {
        // Descongelar al personaje
        isFrozen = false;
    }

    // M�todo que se llama una vez por cuadro despu�s de que se hayan actualizado todos los objetos
    private void LateUpdate()
    {
        // Si el personaje est� congelado, moverlo solo en la direcci�n en la que se estaba moviendo
        if (isFrozen)
        {
            transform.Translate(frozenDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }

}

