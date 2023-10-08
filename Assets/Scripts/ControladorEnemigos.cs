using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject panelVictoria;

    private void Update()
    {
        // Verifica si no hay hijos en el padre "Enemies"
        if (transform.childCount == 0)
        {
            Time.timeScale = 0f;
            // Desactiva el panel BotonPausa y activa el panel Victoria
            botonPausa.SetActive(false);
            panelVictoria.SetActive(true);
        }
    }
}
