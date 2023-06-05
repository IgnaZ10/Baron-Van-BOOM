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

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        initialPosition = transform.position;
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
            }
            else if (distanceToInitialPosition > returnDistance)
            {
                navMeshAgent.destination = initialPosition;
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

