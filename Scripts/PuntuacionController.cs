using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuntuacionController : MonoBehaviour
{
    public Bola bola;
    public GameObject Derrota, PanelF, E1, E2, E3;
    public float Score, SMin, SMid, SMax;
    public int nextScene;

    // Update is called once per frame
    void Start()
    {
        bola = FindObjectOfType<Bola>();
        //Score = bola.score;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;


    }

    public void Update()
    {
        Score = bola.GetComponent<Bola>().score;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PanelF.SetActive(true);
            Debug.Log("Se activa el panel");
            if (Score <= SMin)
            {
                //Panel derrota
                Derrota.SetActive(true);
                Debug.Log(Score + "  Pnt menor que minima");
            }
            else if (Score > SMin && Score < SMid)
            {
                //1 Estrella
                estrella1();
                Debug.Log(Score + "   Pnt 1");
            }
            else if (Score >= SMid && Score < SMax)
            {
                //2 Estrellas
                estrella2();
                Debug.Log(Score + "   Pnt 2");
            }
            else if (Score > SMax)
            {
                //3 Estrellas
                estrella3();
                Debug.Log(Score + "   Pnt 3");
            }
            if (nextScene > PlayerPrefs.GetInt("nivel"))
            {
                PlayerPrefs.SetInt("nivel", nextScene);
            }
        }

    }
    public void estrella1()
    {
        E1.SetActive(true);
    }
    public void estrella2()
    {
        E2.SetActive(true);
    }
    public void estrella3()
    {
        E3.SetActive(true);
    }
}












/*
. 問
╔[]╝ ADR
.╝╚
*/