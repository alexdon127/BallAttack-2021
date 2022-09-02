using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNivel : MonoBehaviour
{
    public GameObject PanelA, PanelAu,  PanelI, PanelC, PanelP;
    public GameObject gameController;
    public int nextScene;
    public int nextMundo = 0;

    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        gameController = GameObject.FindGameObjectWithTag("AC");
    }

    void Update()
    {

    }

    //Next level

    public void ManejoNivel()
    {
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");

        //Pasar a la escena del siguiente nivel y desbloquearlo, pero si ya no hay mas se va al menu Principal

        if (SceneManager.GetActiveScene().buildIndex == 29)
        {
            SceneManager.LoadScene("MenuPrincipal");
            nextMundo++;
            PlayerPrefs.SetInt("mundo", nextMundo);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    public void Principal()
    {
        //ir a la escena principal
        SceneManager.LoadScene("MenuPrincipal");
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }


    //Pausa
    public void Pausa()
    {
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
        //Activar el menu de pausa
        PanelP.SetActive(true);
        //Parar el juego
        if (Time.timeScale == 1)
        {    //si la velocidad es 1
            Time.timeScale = 0;//que la velocidad del juego sea 0
        }
    }

    public void retrocederP()
    {
        PanelP.SetActive(false);
        //Reanudar el juego
        if (Time.timeScale == 0)
        {   // si la velocidad es 0
            Time.timeScale = 1;// que la velocidad del juego regrese a 1
        }
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }


    //Ajustes
    public void ajustes()
    {
        //Activar el menu de ajustes
        PanelA.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    public void retrocederAj()
    {
        PanelA.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    public void Auudio()
    {
        //Activar el Scroll
        PanelAu.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    //-->Scroll<--

    public void retrocederAu()
    {
        PanelAu.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    public void idioma()
    {
        //Activar el menu idiomas
        PanelI.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    public void retrocederI()
    {
        PanelI.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    public void creditos()
    {
        //Activar los creditos
        PanelC.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    public void retrocederC()
    {
        PanelC.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

}









/*
. 問
╔[]╝ ADR
.╝╚
*/