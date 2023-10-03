using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public CharacterController Controller1;
    public GameObject bombPrefab; // Prefab de la bomba
    public event System.Action OnPlayerDestroyed;
    [Range(0,12)]
    [SerializeField] public int contBombas;
    [SerializeField] public int BombasEnPantalla;
    [SerializeField] public int maxBombas = 3;
    public Animation anim;
    Quaternion rotacion;

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
            // Obtén la posición actual del jugador
            Vector3 jugadorPosicion = transform.position;

            // Añade un desplazamiento vertical a la posición del jugador
            jugadorPosicion.y += 3.4f; // Puedes ajustar el valor según tu preferencia

            // Crea una nueva instancia de la bomba en la posición ajustada
            Instantiate(bombPrefab, jugadorPosicion, Quaternion.identity);

            contBombas--;
            BombasEnPantalla++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
           
            rotacion = Quaternion.Euler(0f, 90f, 0f);
            anim.gameObject.transform.rotation = rotacion;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotacion = Quaternion.Euler(0f, -90f, 0f);
            anim.gameObject.transform.rotation = rotacion;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rotacion = Quaternion.Euler(0f, 0f, 0f);
            anim.gameObject.transform.rotation = rotacion;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rotacion = Quaternion.Euler(0f, 180f, 0f);
            anim.gameObject.transform.rotation = rotacion;
        }

        if (x != 0f || z != 0f)
        {
            anim.Play("Caminar");
        }
        else
        {
            anim.Play("Quieto");
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

