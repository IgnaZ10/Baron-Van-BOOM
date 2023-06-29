using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public float airForce = 10f;  // Fuerza de la corriente de aire
    public Vector3 direction = Vector3.forward;  // Direcci�n en la que la corriente de aire empujar� al jugador

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            // Aplicar una fuerza al jugador en la direcci�n especificada
            playerRigidbody.AddForce(direction * airForce);
        }
    }
}


