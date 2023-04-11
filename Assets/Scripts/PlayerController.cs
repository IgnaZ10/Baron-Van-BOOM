using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // La velocidad de movimiento del personaje
    private bool isFrozen = false; // Variable que indica si el personaje está congelado
    private Vector3 frozenDirection; // Variable que almacena la dirección en la que se mueve el personaje antes de congelarse

    // Método que se llama una vez por cuadro
    private void Update()
    {
        // Solo permitir el movimiento si el personaje no está congelado
        if (!isFrozen)
        {
            // Obtener la entrada de movimiento horizontal y vertical
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Crear un vector de movimiento en función de la entrada del jugador
            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

            // Normalizar el vector de movimiento para que no se mueva más rápido en diagonal
            movement.Normalize();

            // Multiplicar el vector de movimiento por la velocidad de movimiento y por el tiempo transcurrido desde el último cuadro
            movement *= moveSpeed * Time.deltaTime;

            // Mover el personaje en función del vector de movimiento
            transform.Translate(movement, Space.World);
        }
    }

    // Método que se llama cuando el personaje colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionó tiene un BoxCollider
        if (collision.collider is BoxCollider)
        {
            // Congelar al personaje en la dirección en la que se estaba moviendo
            isFrozen = true;
            frozenDirection = transform.forward;
        }
    }

    // Método que se llama cuando el personaje deja de colisionar con otro objeto
    private void OnCollisionExit(Collision collision)
    {
        // Descongelar al personaje
        isFrozen = false;
    }

    // Método que se llama una vez por cuadro después de que se hayan actualizado todos los objetos
    private void LateUpdate()
    {
        // Si el personaje está congelado, moverlo solo en la dirección en la que se estaba moviendo
        if (isFrozen)
        {
            transform.Translate(frozenDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }

}

