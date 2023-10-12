using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionRobot : MonoBehaviour
{
    public GameObject particleSystemPrefab; // El sistema de partículas que se instanciará
    public float particleSystemLifetime = 2f; // La duración del sistema de partículas antes de autodestruirse

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (gameObject.CompareTag("Enemy") && !isQuitting && SceneManager.GetActiveScene().isLoaded)
        {
            // Instanciar el sistema de partículas en la posición del objeto que se está destruyendo
            GameObject particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);

            // Obtener el componente ParticleSystem del sistema de partículas instanciado
            ParticleSystem particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();

            // Autodestruir el sistema de partículas después de particleSystemLifetime segundos
            Destroy(particleSystemInstance, particleSystemLifetime);

            // Reproducir el sistema de partículas
            particleSystem.Play();
        }
    }
}

