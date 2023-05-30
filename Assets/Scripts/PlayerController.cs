using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public CharacterController Controller1;
    public GameObject bombPrefab; // Prefab de la bomba
    public event System.Action OnPlayerDestroyed;


    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        Controller1.Move(move * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Crea una nueva instancia de la bomba en la posici�n del jugador
            
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destruye el jugador
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        // Llamada al evento cuando el jugador es destruido
        if (OnPlayerDestroyed != null)
        {
            OnPlayerDestroyed.Invoke();
        }
    }
    /*void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.fixedDeltaTime;
        }

        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.fixedDeltaTime;
        }
    }*/

}

