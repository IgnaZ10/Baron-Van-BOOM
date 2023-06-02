using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject goalDestination;
    private GameObject player;
    private bool isPlayerDestroyed = false;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        if (player != null)
        {
            navMeshAgent.destination = player.transform.position;
        }
    }

    void Update()
    {
        if (!isPlayerDestroyed && player != null)
        {
            navMeshAgent.destination = player.transform.position;
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
