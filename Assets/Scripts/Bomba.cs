using UnityEngine;

public class Bomba : MonoBehaviour
{
    [SerializeField] float tiempoExplosion = 3f; 
    [SerializeField] float radioExplosion = 5f; 
    void Start()
    {
        
        Invoke("Explode", tiempoExplosion);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(1000f, transform.position, radioExplosion);
            }
        }
        Destroy(this.gameObject, 0.5f);
    }
}
