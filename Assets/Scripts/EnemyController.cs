using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            // Detener el movimiento si el jugador no está presente
            rb.velocity = Vector3.zero;
            return;
        }
        // Verificar si el jugador ha sido destruido
        if (player.gameObject.activeSelf == false)
        {
            player = null;
            return;
        }
        // Calcula la dirección hacia el jugador
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Aplica una fuerza hacia el jugador
        rb.AddForce(direction * speed, ForceMode.Force);

        // Limita la velocidad máxima del enemigo
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);

       
    }
    
}

