using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interruptor : MonoBehaviour
{
    public bool activo = false;
    public float distanciaActivacion = 2f;
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Presiona E para activar el objeto.");
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Obtener la posici�n del jugador
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 playerPosition = player.transform.position;

            // Obtener la posici�n del interruptor
            Vector3 interruptorPosition = transform.position;

            // Calcular la distancia entre el jugador y el interruptor
            float distancia = Vector3.Distance(playerPosition, interruptorPosition);

            // Verificar si el jugador est� lo suficientemente cerca
            if (distancia <= distanciaActivacion)
            {
                activo = true;
                Debug.Log("El objeto ahora est� activo.");

                if (activo)
                {
                    Destroy(enemy);
                }
            }
        }
    }
}


