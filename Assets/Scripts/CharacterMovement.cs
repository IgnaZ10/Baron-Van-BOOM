using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Obtener el vector de movimiento
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        // Comprueba si hay movimiento
        if (movement != Vector3.zero)
        {
            // Calcula la rotaci�n basada en la direcci�n del movimiento
            Quaternion newRotation = Quaternion.LookRotation(movement);

            // Aplica la rotaci�n al personaje
            rb.rotation = newRotation;

            // Aplica la fuerza al Rigidbody para mover al personaje
            rb.AddForce(movement * speed);
        }
    }
}