using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentBlocks : MonoBehaviour
{
    [SerializeField] private Color originalColor;
    [SerializeField] public Renderer renderer;

    private void Start()
    {
        // Al iniciar, obtenemos el componente Renderer y el color original del objeto
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    private void OnMouseEnter()
    {
        // Verificamos si el objeto tiene el tag "Unbreakable"
        if (CompareTag("Unbreakable"))
        {
            // Cambiamos el color del material para que sea transparente
            Color newColor = originalColor;
            newColor.a = 0.5f; // Puedes ajustar este valor para cambiar la transparencia
            renderer.material.color = newColor;
        }
    }

    private void OnMouseExit()
    {
        // Verificamos si el objeto tiene el tag "Unbreakable"
        if (CompareTag("Unbreakable"))
        {
            // Restauramos el color original del material
            renderer.material.color = originalColor;
        }
    }
}
