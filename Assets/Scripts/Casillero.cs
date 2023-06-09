using UnityEngine;

public class Casillero : MonoBehaviour
{
    public GameObject objectToInstantiate; // El objeto que deseas instanciar
    public float yOffset = 1f; // Desplazamiento vertical
    public int maxCajas = 10; // L�mite de cajas

    public static int cajasInstanciadas = 0; // Contador de cajas instanciadas

    private void OnDisable()
    {
        // Reiniciar la cantidad de cajas instanciadas al desactivar el objeto
        cajasInstanciadas = 0;
    }
    private void Update()
    {
        // Verificar si el juego est� pausado
        if (Time.timeScale == 0f)
        {
            return; // Salir del m�todo sin hacer nada si el juego est� pausado
        }
        if (Input.GetMouseButtonDown(0) && cajasInstanciadas < maxCajas)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Comprueba si el objeto clickeado es el que tiene este script
                if (hit.collider.gameObject == gameObject)
                {
                    Vector3 spawnPosition = hit.transform.position + new Vector3(0f, yOffset, 0f);

                    // Verificar si hay colisiones en la posici�n de spawn
                    Collider[] colliders = Physics.OverlapSphere(spawnPosition, 3.2f);
                    if (colliders.Length == 0)
                    {
                        Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
                        cajasInstanciadas++; // Incrementa el contador de cajas instanciadas
                    }
                }
            }
        }
    }
}



