using UnityEngine;

public class animatorController : MonoBehaviour
{
    [SerializeField] Animator anim;

    [Range(-1, 1)]
    [SerializeField] float horizontal;

    [Range(-1, 1)]
    [SerializeField] float vertical;

    [Range(0, 10)]
    [SerializeField] float velocidad;



    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            Adelante(Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            Atras(Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            Derecha(Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            Izquierda(Time.deltaTime);

        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical", vertical);
    }

    void Adelante(float tdt)
    {
        transform.position += Vector3.forward * tdt * velocidad;

        vertical += tdt;
        if (vertical > 1) vertical = 1;
    }
    void Atras(float tdt)
    {
        transform.position += Vector3.back * tdt * velocidad;
        vertical -= tdt;
        if (vertical < -1) vertical = -1;
    }
    void Derecha(float tdt)
    {
        horizontal += tdt;
        if (horizontal > 1) horizontal = 1;
        transform.position += Vector3.right * tdt * velocidad;
    }
    void Izquierda(float tdt)
    {
        horizontal -= tdt;
        if (horizontal < -1) horizontal = -1;
        transform.position += Vector3.left * tdt * velocidad;
    }
}
