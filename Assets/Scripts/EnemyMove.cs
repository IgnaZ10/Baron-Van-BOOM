using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject goalDestination;
    public float chasingDistance = 5f; // Distancia para comenzar a perseguir al jugador
    public float returnDistance = 30f; // Distancia para volver al punto inicial
    private GameObject player;
    private Vector3 initialPosition;
    private bool isPlayerDestroyed = false;
    private Animation anim;

    public float arrivalDistance = 0.01f; // Distancia mínima al punto inicial antes de activar la animación de estar quieto
    public float animationSpeedVariation = 0.1f; // Variación de velocidad de animación

     

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        initialPosition = transform.position;
        anim = GetComponent<Animation>();

        // Aplicar una pequeña variación de velocidad de animación para evitar la sincronización
        float randomSpeedFactor = Random.Range(1f - animationSpeedVariation, 1f + animationSpeedVariation);
        anim[anim.clip.name].speed = randomSpeedFactor;
    }

    void Update()
    {
        if (!isPlayerDestroyed && player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            float distanceToInitialPosition = Vector3.Distance(transform.position, initialPosition);

            if (distanceToPlayer <= chasingDistance)
            {
                navMeshAgent.destination = player.transform.position;

                // Activa la animación de persecución.
                anim.Play("Armature|Persecucion");
            }
            else if (distanceToInitialPosition > returnDistance)
            {
                navMeshAgent.destination = initialPosition;

             
            }
            else if (distanceToInitialPosition <= arrivalDistance)
            {
                // Activa la animación de estar quieto.
                anim.Play("Armature|EnGuardia");
            }
        }
    }

    void OnDestroy()
    {
        if (player != null)
        {
            player.GetComponent<PlayerController>().OnPlayerDestroyed -= StopChasingPlayer;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isPlayerDestroyed && other.gameObject == player)
        {
            Destroy(player);
        }
    }

    void StopChasingPlayer()
    {
        isPlayerDestroyed = true;
        navMeshAgent.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}

