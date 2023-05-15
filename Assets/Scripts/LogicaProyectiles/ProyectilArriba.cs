using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilArriba : MonoBehaviour
{
    public float speed = 12f;

    private void Update()
    {  
    Vector3 move = transform.forward * speed * Time.deltaTime;
        
    }
    
}
