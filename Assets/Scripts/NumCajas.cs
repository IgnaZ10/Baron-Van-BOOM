using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCajas : MonoBehaviour
{
    public int cajacontador;
    private Casillero script1Reference;

    private void Start()
    {
        // Obt�n la referencia al script 
        script1Reference = GetComponent<Casillero>();

        // Accede a la variable p�blica de 
        int valorVariable = script1Reference.maxCajas;

    }
}
