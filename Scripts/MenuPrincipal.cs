using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject PanelNi, PanelNB1, PanelNB2, PanelNB3,
        PanelM11, PanelM12, PanelM13,
        PanelM2B, PanelM21, PanelM22, PanelM23,
        PanelM3B, PanelM31, PanelM32, PanelM33,
        PanelA, PanelAu, PanelId, PanelCr, PanelT, PanelS;

    public Button[] niveles;
    public Button[] mundos;

    public GameObject gameController;

    void Start()
    {
        int nivel = PlayerPrefs.GetInt("nivel", 2);
        for (int i = 0; i < niveles.Length; i++)
        {
            if(i + 1 > nivel)
            {
                niveles[i].interactable = false;
            }
        }

        int mundo = PlayerPrefs.GetInt("mundo", 2);

        for (int a = 0; a < mundos.Length; a++)
           {
               if (a + 2 > mundo)
               {
                   mundos[a].interactable = false;
               }
           }

        //Para los sonidos buscamos su gameObject
        gameController = GameObject.FindGameObjectWithTag("AC");
    }

    //Niveles
    public void JugarNivel(string Nivel)
    {
        //Pasar a la escena con el nivel 
        SceneManager.LoadScene(Nivel);

        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    
    //Jugar niveles
    public void Jugar()
    {
        //Activar menu secundario con los mundos 
        PanelNi.SetActive(true);

        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederN()
    {
        PanelNi.SetActive(false);

        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    //Mundo 1
    public void JugarM1()
    {
        //Activar menu secundario con los niveles 
        PanelM11.SetActive(true);

        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederM1()
    {
        PanelM11.SetActive(false);
        PanelM12.SetActive(false);
        PanelM13.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Avanzar1M1() //Pasar pagina de niveles
    {
        PanelM12.SetActive(true);
        PanelM11.SetActive(false); 
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Avanzar2M1()
    { 
        PanelM13.SetActive(true);
        PanelM12.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederP1M1() //Retroceder pagina de niveles
    {
        PanelM11.SetActive(true);
        PanelM12.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederP2M1()
    {
        PanelM12.SetActive(true);
        PanelM13.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    //Mundo 2
    public void JugarM2()
    {
        //Activar menu secundario con los niveles 
        PanelM21.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederM2()
    {
        PanelM21.SetActive(false);
        PanelM22.SetActive(false);
        PanelM23.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Avanzar1M2() //Pasar pagina de niveles
    {
        PanelM22.SetActive(true);
        PanelM21.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Avanzar2M2()
    {
        PanelM23.SetActive(true);
        PanelM22.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederP1M2() //Retroceder pagina de niveles
    {
        PanelM21.SetActive(true);
        PanelM22.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederP2M2()
    {
        PanelM22.SetActive(true);
        PanelM23.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    //Mundo 3
    public void JugarM3()
    {
        //Activar menu secundario con los niveles 
        PanelM31.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederM3()
    {
        PanelM31.SetActive(false);
        PanelM32.SetActive(false);
        PanelM33.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Avanzar1M3() //Pasar pagina de niveles
    {
        PanelM32.SetActive(true);
        PanelM31.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Avanzar2M3()
    {
        PanelM33.SetActive(true);
        PanelM32.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederP1M3() //Retroceder pagina de niveles
    {
        PanelM31.SetActive(true);
        PanelM32.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederP2M3()
    {
        PanelM32.SetActive(true);
        PanelM33.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    //Mundo 3 bloqueado
    public void MensajeM3B()
    {
        PanelM3B.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void QMensajeM3B()
    {
        PanelM3B.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    //Ajustes
    public void Ajustes()
    {
        //Activar el menu de ajustes
        PanelA.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederA()
    {
        PanelA.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Auddio()
    {
        //Activar el menu de ajustes
        PanelAu.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederAu()
    {
        PanelAu.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Idioma()
    {
        //Activar el menu de ajustes
        PanelId.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederId()
    {
        PanelId.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Creditos()
    {
        //Activar el menu de ajustes
        PanelCr.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederCr()
    {
        PanelCr.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    //Skins y Tienda Preguntar como hacerlo
    public void Skins()
    {
        PanelS.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederS()
    {
        PanelS.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void Tienda()
    {
        //proximamente
        PanelT.SetActive(true);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }
    public void RetrocederT()
    {
        PanelT.SetActive(false);
        //Activamos su sonido
        gameController.SendMessage("SonarBoton");
    }

    //Salir
    public void Salir()
    {
        Application.Quit();
    }

}









/*
. 問
╔[]╝ ADR
.╝╚
*/