using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInicial : MonoBehaviour
{
    [SerializeField] GameObject ViewTutorialPanel;
    public AudioSource audioSource;
    public AudioClip sonido;
    private void Start()
    {
        ViewTutorialPanel.SetActive(false);
    }
    public void Jugar(string Nivel1)
    {
        audioSource.PlayOneShot(sonido);
        SceneManager.LoadScene(Nivel1);
    }

    public void Salir()
    {
        audioSource.PlayOneShot(sonido);
        Debug.Log("Salir...");
        Application.Quit();

    }
    public void VerTutorial()
    {
        audioSource.PlayOneShot(sonido);
        SceneManager.LoadScene("Tutorial");
    }
    public void InicioJuego()
    {
        audioSource.PlayOneShot(sonido);
        ViewTutorialPanel.SetActive(true);
    }
    public void VerOpciones()
    {
        audioSource.PlayOneShot(sonido);
    }  
}
