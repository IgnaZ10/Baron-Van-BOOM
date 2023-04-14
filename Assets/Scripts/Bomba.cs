using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float tiempoExplosion = 3f; // El tiempo que tarda la bomba en explotar
    public float radioExplosion = 5f; // El radio de la explosión de la bomba

    private bool haExplotado = false; // Indica si la bomba ha explotado
    private float tiempoRestante; // Tiempo restante para que la bomba explote

    void Start()
    {
        tiempoRestante = tiempoExplosion;
    }

    void Update()
    {
        if (!haExplotado)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0f)
            {
                Explode();
            }
        }
    }

    void Explode()
    {
        haExplotado = true;
        GetComponent<MeshRenderer>().enabled = true;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(1000f, transform.position, radioExplosion);
            }
        }

        GameObject gameObjectToDisable = GameObject.Find("BombPrefab(Clone)");
        Destroy(gameObjectToDisable, 0.5f);
        
    }
}
