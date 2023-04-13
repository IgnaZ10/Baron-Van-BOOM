using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombPlacement : MonoBehaviour
{
    public float tiempoDeEspera = 3.0f; // tiempo que tarda la bomba en explotar
    public float radioDeExplosion = 5.0f; // radio de la explosión
    public GameObject explosionPrefab; // prefabricado del objeto de explosión

    private bool explotado = false; // variable booleana para controlar si la bomba ya ha explotado o no

    void Start()
    {
        StartCoroutine(ContarHastaExplotar());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !explotado)
        {
            Explotar();
        }
    }

    IEnumerator ContarHastaExplotar()
    {
        yield return new WaitForSeconds(tiempoDeEspera);
        if (!explotado)
        {
            Explotar();
        }
    }

    void Explotar()
    {
        explotado = true;
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().ConfigurarExplosion(radioDeExplosion);
        Destroy(gameObject);
    }
}
