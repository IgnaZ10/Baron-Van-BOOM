using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public Transform player;

    [SerializeField] private GameObject GameOver;

    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

    [SerializeField] private GameObject menuOpciones;

    private bool juegoPausado = false;
    private bool reinicioSolicitado = false;
    private void Update()
    {
        // Verificar si el objeto del jugador no está presente
        if (player == null)
        {
            Time.timeScale = 0f;
            botonPausa.SetActive(false);
            GameOver.SetActive(true);
           
        }
        if (reinicioSolicitado)
        {
            if (!juegoPausado)
            {
                Reiniciar();
            }
            reinicioSolicitado = false;
        }

    }

    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void BackOpciones()
    {
        menuOpciones.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Opciones()
    {
        menuOpciones.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Cerrar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenu");
    }
    public void SolicitarReinicio()
    {
        reinicioSolicitado = true;
    }

}
