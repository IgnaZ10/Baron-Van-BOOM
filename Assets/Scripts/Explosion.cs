using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float tiempoDeVida = 0.5f; // tiempo que tarda la explosión en desaparecer
    public LayerMask capasObjetosDestructibles; // capas de objetos que pueden ser destruidos por la explosión
    public GameObject particulasExplosionPrefab; // prefabricado del objeto de partículas de explosión

    private float radio; // radio de la explosión

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    public void ConfigurarExplosion(float radio)
    {
        this.radio = radio;
        RaycastHit hit;
        Vector3 origen = transform.position;
        Vector3 direccion;

        // Lanzar rayos en todas las direcciones para detectar los objetos que deben ser destruidos
        for (int i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 0: direccion = Vector3.right; break;
                case 1: direccion = Vector3.left; break;
                case 2: direccion = Vector3.forward; break;
                case 3: direccion = Vector3.back; break;
                default: direccion = Vector3.zero; break;
            }
            for (float j = 1; j <= radio; j++)
            {
                Vector3 destino = origen + (direccion * j);
                if (Physics.Raycast(origen, direccion, out hit, j, capasObjetosDestructibles))
                {
                    // Si se encuentra un objeto destructible, se lo destruye
                    DestroyObjetoDestructible(hit.collider.gameObject);
                    break;
                }
                else
                {
                    // Si no se encuentra un objeto destructible, se crea una partícula de explosión en ese punto
                    Instantiate(particulasExplosionPrefab, destino, Quaternion.identity);
                }
            }
        }
    }

    void DestroyObjetoDestructible(GameObject objeto)
    {
        // Método para destruir un objeto destructible y crear una partícula de explosión en su lugar
        Instantiate(particulasExplosionPrefab, objeto.transform.position, Quaternion.identity);
        Destroy(objeto);
    }

    void OnDestroy()
    {
        // Se destruyen todas las partículas de explosión creadas en esta explosión
        GameObject[] particulas = GameObject.FindGameObjectsWithTag("ParticulasExplosion");
        foreach (GameObject particula in particulas)
        {
            Destroy(particula);
        }
    }
}
