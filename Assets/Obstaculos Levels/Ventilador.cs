using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public float airForce = 10f;  // Fuerza de la corriente de aire
    public Vector3 direction = Vector3.forward;  // Dirección en la que la corriente de aire empujará al jugador

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            // Aplicar una fuerza al jugador en la dirección especificada
            playerRigidbody.AddForce(direction * airForce);
        }
    }
}


