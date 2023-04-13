using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float tiempoDeVida = 0.5f; // tiempo que tarda la explosi�n en desaparecer
    public LayerMask capasObjetosDestructibles; // capas de objetos que pueden ser destruidos por la explosi�n
    public GameObject particulasExplosionPrefab; // prefabricado del objeto de part�culas de explosi�n

    private float radio; // radio de la explosi�n

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
                    // Si no se encuentra un objeto destructible, se crea una part�cula de explosi�n en ese punto
                    Instantiate(particulasExplosionPrefab, destino, Quaternion.identity);
                }
            }
        }
    }

    void DestroyObjetoDestructible(GameObject objeto)
    {
        // M�todo para destruir un objeto destructible y crear una part�cula de explosi�n en su lugar
        Instantiate(particulasExplosionPrefab, objeto.transform.position, Quaternion.identity);
        Destroy(objeto);
    }

    void OnDestroy()
    {
        // Se destruyen todas las part�culas de explosi�n creadas en esta explosi�n
        GameObject[] particulas = GameObject.FindGameObjectsWithTag("ParticulasExplosion");
        foreach (GameObject particula in particulas)
        {
            Destroy(particula);
        }
    }
}
