using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCajas : MonoBehaviour
{
    public int cajacontador;
    private Casillero script1Reference;

    private void Start()
    {
        // Obtén la referencia al script 
        script1Reference = GetComponent<Casillero>();

        // Accede a la variable pública de 
        int valorVariable = script1Reference.maxCajas;

    }
}
