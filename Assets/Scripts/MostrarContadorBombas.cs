using UnityEngine;
using UnityEngine.UI;

public class MostrarContadorBombas : MonoBehaviour
{
    public PlayerController playerController;
    public Text textoContador;

    private void Start()
    {
        // Obtenemos una referencia al script PlayerController del objeto Player
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        // Verificamos si se encontró el PlayerController
        if (playerController == null)
        {
            Debug.LogError("No se encontró el PlayerController en el objeto Player.");
        }
    }

    private void Update()
    {
        // Actualizamos el texto del contador con el valor de contBombas
        textoContador.text = playerController.contBombas.ToString();
    }
}
