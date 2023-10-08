using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuInicial : MonoBehaviour
{
    [SerializeField] GameObject ViewTutorialPanel;
    public AudioSource audioSource;
    public AudioClip sonido;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject menuPrincipal;
    private void Start()
    {
        ViewTutorialPanel.SetActive(false);
    }
    public void Jugar(string Nivel1)
    {
        SceneManager.LoadScene(Nivel1);
    }

    public void Salir()
    {
        audioSource.PlayOneShot(sonido);
        Debug.Log("Salir...");
        Application.Quit();

    }
    public void Opciones()
    {
        audioSource.PlayOneShot(sonido);
        menuOpciones.SetActive(true);
        menuPrincipal.SetActive(false);
    }
    public void volverOpciones()
    {
        audioSource.PlayOneShot(sonido);
        menuOpciones.SetActive(false);
        menuPrincipal.SetActive(true);
    }
    public void VerTutorial()
    {
        
        SceneManager.LoadScene("Tutorial");
    }
    public void InicioJuego()
    {
        audioSource.PlayOneShot(sonido);
        ViewTutorialPanel.SetActive(true);
    }
}
