using UnityEngine;

public class Bomba : MonoBehaviour
{
    [SerializeField] float tiempoExplosion = 0f; 
    public float radioExplosion = 5f;
    public float duracionExplosion = 3f;
    
    
    void Start()
    {
        
        Invoke("Explode", tiempoExplosion);
    }
    void Explode()
    {
        while (tiempoExplosion < duracionExplosion)
        {
            tiempoExplosion += Time.deltaTime;

            // Lanzar raycast hacia la izquierda
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.right, out hit, radioExplosion))
            {
                // Si el raycast alcanza un objeto, hacer algo con el objeto
                Debug.Log("Objeto alcanzado: " + hit.collider.name);
            }

            // Lanzar raycast hacia la derecha
            if (Physics.Raycast(transform.position, transform.right, out hit, radioExplosion))
            {
                // Si el raycast alcanza un objeto, hacer algo con el objeto
                Debug.Log("Objeto alcanzado: " + hit.collider.name);
            }

            // Lanzar raycast hacia adelante
            if (Physics.Raycast(transform.position, transform.forward, out hit, radioExplosion))
            {
                // Si el raycast alcanza un objeto, hacer algo con el objeto
                Debug.Log("Objeto alcanzado: " + hit.collider.name);
            }

            // Lanzar raycast hacia atrás
            if (Physics.Raycast(transform.position, -transform.forward, out hit, radioExplosion))
            {
                // Si el raycast alcanza un objeto, hacer algo con el objeto
                Debug.Log("Objeto alcanzado: " + hit.collider.name);
            }
            Destroy(this.gameObject, 0.5f);
    }

    }
}
