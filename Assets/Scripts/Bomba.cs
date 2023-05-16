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
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, radioExplosion))
        {
            Debug.Log(hit.collider.name);
            Debug.DrawLine(transform.position, transform.forward * radioExplosion);
            
        }
        
        Destroy(gameObject, 0.5f);
    }
    
}

