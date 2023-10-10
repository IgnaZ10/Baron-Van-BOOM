using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBombController : MonoBehaviour
{
    [SerializeField] private float velocidadExplosion;
    private void Start()
    {
        SelfDestruct();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime * velocidadExplosion);
    }
    private void SelfDestruct()
    {
        Destroy(this.gameObject,1f);
    }
}
