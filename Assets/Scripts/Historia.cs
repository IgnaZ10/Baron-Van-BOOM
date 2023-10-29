using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Historia : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] LineasTutorial;
    [SerializeField] private GameObject panelTutorial;
    [SerializeField] private Text textTutorial;
    private int LineIndex = 0;
    public float tiempoEscritura = 0.03f;
    [SerializeField] private AudioSource letra;
    [SerializeField] private AudioClip letraBit;

    // Variable para controlar si el texto se ha terminado de mostrar
    private bool isTextFinished = false;

    private void Start()
    {
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        isTextFinished = false; // Inicializamos a false al comienzo de cada línea
        textTutorial.text = string.Empty;

        foreach (char ch in LineasTutorial[LineIndex])
        {
            textTutorial.text += ch;
            yield return new WaitForSeconds(tiempoEscritura);
            letra.clip = letraBit;
            letra.Play();
        }

        isTextFinished = true; // Marcamos como true cuando el texto se ha mostrado completamente
    }

    private void NextDialogue()
    {
        if (!isTextFinished) // Si el texto no se ha terminado de mostrar, no hacemos nada
            return;

        LineIndex++;
        if (LineIndex < LineasTutorial.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
