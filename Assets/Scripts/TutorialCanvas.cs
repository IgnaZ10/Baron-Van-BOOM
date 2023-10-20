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
    private void Start()
    {
        StartCoroutine(ShowLine());
    }
    private IEnumerator ShowLine()
    {
        textTutorial.text = string.Empty;

        foreach (char ch in LineasTutorial[LineIndex])
        {
            textTutorial.text += ch;
            yield return new WaitForSeconds(tiempoEscritura);
            letra.clip = letraBit;
            letra.Play();
        }
    }
    private void NextDialogue()
    {
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
