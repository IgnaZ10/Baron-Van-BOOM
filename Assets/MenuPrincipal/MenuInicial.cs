using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] GameObject ViewTutorialPanel;
    private void Start()
    {
        ViewTutorialPanel.SetActive(false);
    }
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
    public void VerTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void InicioJuego()
    {
        ViewTutorialPanel.SetActive(true);
    }
}
