using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocaBomba : MonoBehaviour
{
    public GameObject bombaPrefab; // prefabricado del objeto de bomba
    public float velocidadMovimiento = 5.0f; // velocidad de movimiento del jugador
    public float tiempoEntreBombas = 2.0f; // tiempo mínimo entre colocar bombas
    public int maximoBombasSimultaneas = 1; // cantidad máxima de bombas que pueden estar en el mapa a la vez

    private float tiempoUltimaBomba; // tiempo en el que se colocó la última bomba
    private int bombasSimultaneasActuales = 0; // cantidad actual de bombas en el mapa
    private bool puedeColocarBomba = true; // si el jugador puede colocar una bomba en este momento

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedeColocarBomba && bombasSimultaneasActuales < maximoBombasSimultaneas)
        {
            // Si el jugador presiona la tecla de espacio y puede colocar una bomba y no hay demasiadas bombas en el mapa,
            // se crea una nueva bomba en la posición del jugador y se incrementa el contador de bombas en el mapa
            GameObject nuevaBomba = Instantiate(bombaPrefab, transform.position, Quaternion.identity) as GameObject;
            nuevaBomba.GetComponent<PlayerBombPlacement>().InicializarBomba();
            bombasSimultaneasActuales++;
            tiempoUltimaBomba = Time.time;
            if (bombasSimultaneasActuales >= maximoBombasSimultaneas)
            {
                // Si se alcanza el límite de bombas en el mapa, el jugador ya no puede colocar más bombas hasta que alguna explote
                puedeColocarBomba = false;
            }
        }

        if (!puedeColocarBomba && bombasSimultaneasActuales == 0)
        {
            // Si no puede colocar bombas pero ya no hay bombas en el mapa, el jugador puede colocar una nueva bomba
            puedeColocarBomba = true;
        }

        if (Time.time - tiempoUltimaBomba > tiempoEntreBombas)
        {
            // Si ha pasado suficiente tiempo desde la última bomba, el jugador puede colocar una nueva bomba
            puedeColocarBomba = true;
        }
    }

    public void BombaExploto()
    {
        // Se llama a este método desde la bomba cuando explota, para indicar al jugador que hay una bomba menos en el mapa
        bombasSimultaneasActuales--;
    }
}
