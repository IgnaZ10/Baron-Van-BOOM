using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float tiempoExplosion = 3f; // El tiempo que tarda la bomba en explotar
    public float radioExplosion = 10f; // El radio de la explosión de la bomba
    
    private bool haExplotado = false; // Indica si la bomba ha explotado
    private float tiempoRestante; // Tiempo restante para que la bomba explote
    private ExplosionController explodeController;

    void Start()
    {
        tiempoRestante = tiempoExplosion;
        explodeController = FindObjectOfType<ExplosionController>();
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
        explodeController.Explotar(transform.position);
        haExplotado = true;
        Vector3[] directions = { Vector3.back, Vector3.right, Vector3.forward, Vector3.left };

        foreach (Vector3 direction in directions)
        {
            RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, radioExplosion);

            foreach (RaycastHit hit in hits)
            {

                BreakScript ruptura = hit.transform.GetComponent<BreakScript>();
                if (ruptura)
                    Destroy(ruptura.transform.gameObject, 1f);

                
            }

            Debug.DrawRay(transform.position, direction * radioExplosion, Color.red, 1f);
        }

        PlayerController playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.BombasEnPantalla--;
        }

        Destroy(gameObject, 0.5f);
    }
    

}

