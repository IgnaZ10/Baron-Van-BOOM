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
            // Calcula la rotación basada en la dirección del movimiento
            Quaternion newRotation = Quaternion.LookRotation(movement);

            // Aplica la rotación al personaje
            rb.rotation = newRotation;

            // Aplica la fuerza al Rigidbody para mover al personaje
            rb.AddForce(movement * speed);
        }
    }
}