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

    private bool juegoPausado = false;
    private bool reinicioSolicitado = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
        // Verificar si el objeto del jugador no est� presente
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

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
