using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionRobot : MonoBehaviour
{
    public GameObject particleSystemPrefab; // El sistema de part�culas que se instanciar�
    public float particleSystemLifetime = 2f; // La duraci�n del sistema de part�culas antes de autodestruirse

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (gameObject.CompareTag("Enemy") && !isQuitting && SceneManager.GetActiveScene().isLoaded)
        {
            // Instanciar el sistema de part�culas en la posici�n del objeto que se est� destruyendo
            GameObject particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

            // Obtener el componente ParticleSystem del sistema de part�culas instanciado
            ParticleSystem particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();

            // Autodestruir el sistema de part�culas despu�s de particleSystemLifetime segundos
            Destroy(particleSystemInstance, particleSystemLifetime);

            // Reproducir el sistema de part�culas
            particleSystem.Play();
        }
    }
}

