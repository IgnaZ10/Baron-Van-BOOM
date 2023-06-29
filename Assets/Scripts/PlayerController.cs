using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public CharacterController Controller1;
    public GameObject bombPrefab; // Prefab de la bomba
    public event System.Action OnPlayerDestroyed;
    public int contBombas;
    [SerializeField] public int BombasEnPantalla;
    [SerializeField] public int maxBombas = 3;

    private void Awake()
    {
        contBombas = 20;

    }

    private void Update()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y, 0);
        Controller1.Move(gravity * Time.deltaTime);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        Controller1.Move(move * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && contBombas > 0 && BombasEnPantalla < maxBombas)
        {
            // Crea una nueva instancia de la bomba en la posición del jugador

            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            contBombas--;
            BombasEnPantalla++;
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

}

