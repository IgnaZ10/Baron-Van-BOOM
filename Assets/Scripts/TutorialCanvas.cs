using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialCanvas : MonoBehaviour
{
    [SerializeField, TextArea(4,6)] private string[] LineasTutorial;
    [SerializeField] private GameObject panelTutorial;
    [SerializeField] private Text textTutorial;
    private int LineIndex = 0;
    public float tiempoEscritura = 0.03f;
    [SerializeField] private AudioSource letra;
    [SerializeField] private AudioClip letraBit;

    private bool isTextFinished = false;
    private void Start()
    {
        StartCoroutine(ShowLine());
    }
    private IEnumerator ShowLine()
    {
        isTextFinished = false;
        textTutorial.text = string.Empty;

        foreach (char ch in LineasTutorial[LineIndex])
        {
            textTutorial.text += ch;
            yield return new WaitForSeconds(tiempoEscritura);
            letra.clip = letraBit;
            letra.Play();
        }
        isTextFinished = true;
    }
    private void NextDialogue()
    {
        if (!isTextFinished) 
            return;

        LineIndex++;
        if (LineIndex < LineasTutorial.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            SceneManager.LoadScene("Nivel 1");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }
    }
}
