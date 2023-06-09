using UnityEngine;
using UnityEngine.UI;

public class CajasContador : MonoBehaviour
{
    public Casillero casillero;
    public Text textoContador;

    private void Start()
    {
        // Obtenemos una referencia al script PlayerController del objeto Player
        casillero = GameObject.FindWithTag("Casillero").GetComponent<Casillero>();

        // Verificamos si se encontró el PlayerController
        if (casillero == null)
        {
            Debug.LogError("No se encontró el PlayerController en el objeto Player.");
        }
    }

    private void Update()
    {
        // Actualizamos el texto del contador con el valor de contBombas
        textoContador.text = casillero.maxCajas.ToString();
    }
}
