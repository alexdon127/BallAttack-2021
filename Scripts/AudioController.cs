using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
#pragma warning disable CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
    private AudioSource audio;
#pragma warning restore CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
    public AudioClip clipB, clipM, clipI1, clipI2, clipCo;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SonarMoneda()
    {
        audio.clip = clipM;
        audio.Play();
    }

    public void SonarBoton()
    {
        audio.clip = clipB;
        audio.Play();
    }

    public void SonarItem1()
    {
        audio.clip = clipI1;
        audio.Play();
    }

    public void SonarItem2()
    {
        audio.clip = clipI2;
        audio.Play();
    }
    public void SonarColision()
    {
        audio.clip = clipCo;
        audio.Play();
    }
}








/*
. 問
╔[]╝ ADR
.╝╚
*/