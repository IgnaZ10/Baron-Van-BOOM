using UnityEngine;

public class Casillero : MonoBehaviour
{
    
    public GameObject objectToInstantiate; // El objeto que deseas instanciar
    public float yOffset = 1f; // Desplazamiento vertical

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Comprueba si el objeto clickeado es el que tiene este script
                if (hit.collider.gameObject == gameObject)
                {
                    Vector3 spawnPosition = hit.transform.position + new Vector3(0f, yOffset, 0f);
                    Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}

