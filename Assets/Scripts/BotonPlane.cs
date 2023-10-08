using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPlane : MonoBehaviour
{
    public GameObject objetoParaActivarODesactivar; // Objeto público que se activará o desactivará
    private bool activado = false; // Variable para controlar el estado del interruptor
    private bool cercaDelInterruptor = false; // Variable para controlar la proximidad del jugador
    [SerializeField] private GameObject teclaE;

    public AudioSource audioSource;
    public AudioClip sonidoBoton;
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colisiona con el interruptor es el jugador
        if (other.CompareTag("Player"))
        {
            cercaDelInterruptor = true;
            teclaE.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Comprueba si el jugador sale del área del interruptor
        if (other.CompareTag("Player"))
        {
            cercaDelInterruptor = false;
            teclaE.SetActive(false);
        }
    }

    private void Update()
    {
        // Comprueba si el jugador está cerca del interruptor y ha presionado la tecla "E"
        if (cercaDelInterruptor && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(sonidoBoton);
            // Cambia el estado del interruptor y activa o desactiva el objeto
            activado = !activado;

            if (activado)
            {
                // Activa el objeto
                objetoParaActivarODesactivar.SetActive(true);
                Debug.Log("Interruptor activado");
            }
            else
            {
                // Desactiva el objeto
                objetoParaActivarODesactivar.SetActive(false);
                Debug.Log("Interruptor desactivado");
            }
        }
    }
}

