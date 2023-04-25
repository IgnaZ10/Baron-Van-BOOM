using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakScript : MonoBehaviour
{


    private void FixedUpdate()
    {
        // Verifica si se ha aplicado una fuerza a este objeto
        if (GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            // Busca un objeto llamado "BombPrefab(Clone)" en la escena
            GameObject bomb = GameObject.Find("BombPrefab(Clone)");

            // Si se encuentra la bomba, destruye este objeto
            if (bomb != null)
            {
                Destroy(gameObject);
            }
        }
    }

}
