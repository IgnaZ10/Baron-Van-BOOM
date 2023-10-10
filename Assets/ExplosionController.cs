using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private GameObject prefabEffect;
    public void Explotar(Vector3 posicionExplosion)
    {
        GameObject explosion1 = Instantiate(prefabEffect, posicionExplosion, Quaternion.Euler(0, 0, 0));
        GameObject explosion2 = Instantiate(prefabEffect, posicionExplosion, Quaternion.Euler(0, 90, 0));
        GameObject explosion3 = Instantiate(prefabEffect, posicionExplosion, Quaternion.Euler(0, 180, 0));
        GameObject explosion4 = Instantiate(prefabEffect, posicionExplosion, Quaternion.Euler(0, 270, 0));
    }

}
