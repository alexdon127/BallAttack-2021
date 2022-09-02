using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atraccion : MonoBehaviour
{
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Bola");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "moneda")
        {
            other.transform.position = Vector3.Lerp(other.transform.position, jugador.transform.position, 0.30f);
        }
    }
}
