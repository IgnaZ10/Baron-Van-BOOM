using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentBlocks : MonoBehaviour
{
    public Material startMaterial;
    public Material hoverMaterial;
    bool mouseOver = false;

    private void OnMouseEnter()
    {
        mouseOver = true;
        GetComponent<Renderer>().material = hoverMaterial;
    }


    private void OnMouseExit()

    {
        mouseOver = false;
        GetComponent<Renderer>().material = startMaterial;
    }
}
