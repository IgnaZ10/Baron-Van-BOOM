using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float tiempoExplosion = 3f; // El tiempo que tarda la bomba en explotar
    public float radioExplosion = 100f; // El radio de la explosión de la bomba
    
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
        Vector3 vectorExplode = Vector3.zero;



        for (int explosions = 0; explosions <= 3; explosions++)
        {
            switch (explosions) {
                case 0: vectorExplode = Vector3.back;
                    break;
                case 1:
                    vectorExplode = Vector3.right;
                    break;
                case 2:
                    vectorExplode = Vector3.forward;
                    break;
                case 3:
                    vectorExplode = Vector3.left;
                    break;

            }
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, vectorExplode, radioExplosion);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                BreakScript ruptura = hit.transform.GetComponent<BreakScript>();
                if (ruptura)
                Destroy(ruptura.transform.gameObject, 1f);

            }
        
                //Debug.DrawLine(transform.position, vectorExplode * radioExplosion);
        }
        Destroy(gameObject, 0.5f);
    }
    
}

